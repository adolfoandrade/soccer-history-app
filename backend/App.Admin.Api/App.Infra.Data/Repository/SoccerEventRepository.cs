using App.Domain.Exceptions.SoccerEvent;
using App.Domain.Interfaces;
using App.Domain.Models;
using App.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class SoccerEventRepository : ISoccerEventRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SoccerEventRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(SoccerEvent soccerEvent)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[Events]
                               ([MatchId]
                               ,[Date]
                               ,[HomeTeamId]
                               ,[OutTeamId]
                               ,[Referee]
                               ,[Venue])
                         VALUES
                               (@MatchId
                               ,@Date
                               ,@HomeTeamId
                               ,@OutTeamId
                               ,@Referee
                               ,@Venue)";
                try
                {
                    return await connection.ExecuteAsync(query, soccerEvent);
                }
                catch (Exception ex)
                {
                    throw new AddSoccerEventException(ex.Message, ex);
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[Events] WHERE Id = @id";
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new DeleteSoccerEventException(ex.Message, ex);
                }
            }
        }

        public async Task<SoccerEvent> GetAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT *
                            FROM Events AS E
                            LEFT JOIN Matches AS M ON M.Id = E.Id
                            LEFT JOIN SoccerTeams H ON H.Id = E.HomeTeamId
                            LEFT JOIN SoccerTeams O ON O.Id = E.OutTeamId
                            WHERE E.Id = @Id";
                var queryGoals = $@"SELECT * FROM EventTimeStatistics AS ET
                                    INNER JOIN GoalsStatistics AS G ON G.EventTimeStatisticId = ET.Id
                                    INNER JOIN SoccerTeams AS ST ON ST.Id = ET.SoccerTeamId
                                    WHERE ET.EventId = @Id";
                var queryCards = $@"SELECT * FROM EventTimeStatistics AS ET
                                    INNER JOIN CardsStatistics AS CS ON CS.EventTimeStatisticId = ET.Id
                                    INNER JOIN SoccerTeams AS ST ON ST.Id = ET.SoccerTeamId
                                    WHERE ET.EventId = @Id";
                var queryStatistics = $@"SELECT * FROM EventTimeStatistics AS ET
                                        INNER JOIN EventStatistics AS ES ON ES.EventTimeStatisticId = ET.Id
                                        INNER JOIN SoccerTeams AS ST ON ST.Id = ET.SoccerTeamId
                                        WHERE ET.EventId = @Id";
                try
                {
                    var @event = await connection.QueryAsync<SoccerEvent, Match, SoccerTeam, SoccerTeam, SoccerEvent>(query, (soccerEvent, match, homeTeam, outTeam) =>
                    {
                        soccerEvent.Match = match;
                        soccerEvent.Home = homeTeam;
                        soccerEvent.Out = outTeam;
                        return soccerEvent;
                    }, new { Id = id }, splitOn: "Id");

                    var soccerEvent = @event.FirstOrDefault();

                    var goals = await connection.QueryAsync<EventTimeStatistic, SoccerTeamEventGol, SoccerTeam, EventTimeStatistic>(queryGoals, (eventTime, goal, soccerTeam) =>
                    {
                        eventTime.Goal = goal;
                        eventTime.SoccerTeam = soccerTeam;
                        return eventTime;
                    }, new { Id = id }, splitOn: "Id");

                    var cards = await connection.QueryAsync<EventTimeStatistic, SoccerTeamEventCard, SoccerTeam, EventTimeStatistic>(queryCards, (eventTime, card, soccerTeam) =>
                    {
                        eventTime.Card = card;
                        eventTime.SoccerTeam = soccerTeam;
                        return eventTime;
                    }, new { Id = id }, splitOn: "Id");

                    var statistics = await connection.QueryAsync<EventTimeStatistic, Statistic, SoccerTeam, EventTimeStatistic>(queryStatistics, (eventTime, statistic, soccerTeam) =>
                    {
                        eventTime.Statistic = statistic;
                        eventTime.SoccerTeam = soccerTeam;
                        return eventTime;
                    }, new { Id = id }, splitOn: "Id");

                    if (soccerEvent != null)
                    {
                        soccerEvent.EventTimeStatistics = new List<EventTimeStatistic>();
                        soccerEvent.EventTimeStatistics.AddRange(goals);
                        soccerEvent.EventTimeStatistics.AddRange(cards);
                        soccerEvent.EventTimeStatistics.AddRange(statistics);
                    }

                    return soccerEvent;
                }
                catch (Exception ex)
                {
                    throw new QuerySoccerEventException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<SoccerEvent>> GetByMatchAsync(string match)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT *
                            FROM Events AS E
                            LEFT JOIN Matches AS M ON M.Id = E.Id
                            LEFT JOIN SoccerTeams H ON H.Id = E.HomeTeamId
                            LEFT JOIN SoccerTeams O ON O.Id = E.OutTeamId";
                try
                {
                    return await connection.QueryAsync<SoccerEvent, Match, SoccerTeam, SoccerTeam, SoccerEvent>(query, (soccerEvent, match, homeTeam, outTeam) =>
                    {
                        soccerEvent.Match = match;
                        soccerEvent.Home = homeTeam;
                        soccerEvent.Out = outTeam;
                        return soccerEvent;
                    }, splitOn: "Id");
                }
                catch (Exception ex)
                {
                    throw new QueryByMatchSoccerEventException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<SoccerEvent>> GetBySeasonAsync(int seasonId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"SELECT *
                            FROM Events AS E
                            LEFT JOIN Matches AS M ON M.Id  = E.MatchId
                            LEFT JOIN SoccerTeams H ON H.Id = E.HomeTeamId
                            LEFT JOIN SoccerTeams O ON O.Id = E.OutTeamId
                            WHERE M.CompetitionId = @SeasonId";
                try
                {
                    return await connection.QueryAsync<SoccerEvent, Match, SoccerTeam, SoccerTeam, SoccerEvent>(query, (soccerEvent, match, homeTeam, outTeam) =>
                    {
                        soccerEvent.Match = match;
                        soccerEvent.Home = homeTeam;
                        soccerEvent.Out = outTeam;
                        return soccerEvent;
                    }, new { SeasonId = seasonId }, splitOn: "Id");
                }
                catch (Exception ex)
                {
                    throw new QueryBySeasonSoccerEventException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<SoccerEvent>> FilterAsync(int seasonId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT *
                            FROM Events AS E
                            LEFT JOIN Matches AS M ON M.Id = E.Id
                            LEFT JOIN SoccerTeams H ON H.Id = E.HomeTeamId
                            LEFT JOIN SoccerTeams O ON O.Id = E.OutTeamId";
                try
                {
                    return await connection.QueryAsync<SoccerEvent, Match, SoccerTeam, SoccerTeam, SoccerEvent>(query, (soccerEvent, match, homeTeam, outTeam) =>
                    {
                        soccerEvent.Match = match;
                        soccerEvent.Home = homeTeam;
                        soccerEvent.Out = outTeam;
                        return soccerEvent;
                    }, splitOn: "Id");
                }
                catch (Exception ex)
                {
                    throw new QueryBySeasonSoccerEventException(ex.Message, ex);
                }
            }
        }

        public async Task<int> UpdateAsync(SoccerEvent soccerEvent)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[Events]
                               SET [MatchId] = @MatchId
                                  ,[Date] = @Date
                                  ,[HomeTeamId] = @HomeTeamId
                                  ,[OutTeamId] = @OutTeamId
                                  ,[Referee] = @Referee
                                  ,[Venue] = @Venue
                             WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, soccerEvent);
                }
                catch (Exception ex)
                {
                    throw new UpdateSoccerEventException(ex.Message, ex);
                }
            }
        }
    }
}
