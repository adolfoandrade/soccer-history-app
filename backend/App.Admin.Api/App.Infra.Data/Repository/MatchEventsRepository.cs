using App.Domain.Exceptions;
using App.Domain.Exceptions.SoccerEvent;
using App.Domain.Interfaces;
using App.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class MatchEventsRepository : IMatchEventsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MatchEventsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(MatchEvent matchEvent)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[MatchEvents]
                                   ([EventId]
                                   ,[TeamId]
                                   ,[Type]
                                   ,[Comments]
                                   ,[Detail]
                                   ,[Assist]
                                   ,[Player]
                                   ,[Elapsed]
                                   ,[Extra])
                             VALUES
                                   (@EventId
                                   ,@TeamId
                                   ,@Type
                                   ,@Comments
                                   ,@Detail
                                   ,@Assist
                                   ,@Player
                                   ,@Elapsed
                                   ,@Extra)";
                try
                {
                    return await connection.ExecuteAsync(query, matchEvent);
                }
                catch (Exception ex)
                {
                    throw new AddMatchException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<MatchEvent>> GetByCompetitionAsync(int competitionId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT * FROM [dbo].[MatchEvents] ME
                                LEFT JOIN [dbo].[Events] E ON E.Id = ME.EventId
                                LEFT JOIN [dbo].[Matches] M ON M.Id = E.MatchId
                                WHERE M.CompetitionId = @Id";
                try
                {
                    return await connection.QueryAsync<MatchEvent>(query, new { Id = competitionId });
                }
                catch (Exception ex)
                {
                    throw new QueryMatchEventException(ex.Message, ex);
                }
            }
        }

        public async Task<MatchEvent> HasAsync(int teamId, int eventId, string type, int elapsed, int extra)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[EventId]
                                  ,[TeamId]
                                  ,[Type]
                                  ,[Comments]
                                  ,[Detail]
                                  ,[Assist]
                                  ,[Player]
                                  ,[Elapsed]
                                  ,[Extra]
                              FROM [dbo].[MatchEvents]
                              WHERE [EventId] = @EventId AND [TeamId] = @TeamId AND [Type] = @Type AND [Elapsed] = @Elapsed AND [Extra] = @Extra";
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<MatchEvent>(query, new { 
                        EventId = eventId, 
                        TeamId = teamId, 
                        Type = type, 
                        Elapsed = elapsed, 
                        Extra = extra 
                    });
                }
                catch (Exception ex)
                {
                    throw new QueryMatchEventException(ex.Message, ex);
                }
            }
        }
    }
}
