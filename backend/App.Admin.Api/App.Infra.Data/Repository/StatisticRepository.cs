﻿using App.Domain.Exceptions.Statistic;
using App.Domain.Interfaces;
using App.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public StatisticRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(Statistic entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[Statistics]
                                   ([EventId]
                                   ,[TeamId]
                                   ,[Period]
                                   ,[BallPossession]
                                   ,[GoalAttempts]
                                   ,[ShotsOnGoal]
                                   ,[ShotsOffGoal]
                                   ,[BlockedShots]
                                   ,[CornerKicks]
                                   ,[FreeKicks]
                                   ,[Offsides]
                                   ,[Throwin]
                                   ,[GoalkeeperSaves]
                                   ,[Fouls]
                                   ,[YellowCards]
                                   ,[RedCards]
                                   ,[TotalPasses]
                                   ,[CompletedPasses]
                                   ,[Trackles]
                                   ,[Attacks]
                                   ,[DangerousAttacks])
                             VALUES
                                   (@EventId
                                   ,@TeamId
                                   ,@Period
                                   ,@BallPossession
                                   ,@GoalAttempts
                                   ,@ShotsOnGoal
                                   ,@ShotsOffGoal
                                   ,@BlockedShots
                                   ,@CornerKicks
                                   ,@FreeKicks
                                   ,@Offsides
                                   ,@Throwin
                                   ,@GoalkeeperSaves
                                   ,@Fouls
                                   ,@YellowCards
                                   ,@RedCards
                                   ,@TotalPasses
                                   ,@CompletedPasses
                                   ,@Trackles
                                   ,@Attacks
                                   ,@DangerousAttacks)";
                try
                {
                    return await connection.ExecuteAsync(query, entity);
                }
                catch (Exception ex)
                {
                    throw new AddStatisticException(ex.Message, ex);
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[SoccerTeamsEventStatistics] WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new DeleteStatisticException(ex.Message, ex);
                }
            }
        }

        public async Task<Statistic> HasAsync(int eventId, int teamId, string period)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[EventId]
                                  ,[TeamId]
                                  ,[Period]
                                  ,[BallPossession]
                                  ,[GoalAttempts]
                                  ,[ShotsOnGoal]
                                  ,[ShotsOffGoal]
                                  ,[BlockedShots]
                                  ,[CornerKicks]
                                  ,[FreeKicks]
                                  ,[Offsides]
                                  ,[Throwin]
                                  ,[GoalkeeperSaves]
                                  ,[Fouls]
                                  ,[YellowCards]
                                  ,[RedCards]
                                  ,[TotalPasses]
                                  ,[CompletedPasses]
                                  ,[Trackles]
                                  ,[Attacks]
                                  ,[DangerousAttacks]
                              FROM [dbo].[Statistics]
                              WHERE [EventId] = @EventId AND [TeamId] = @TeamId AND [Period] = @Period";
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<Statistic>(query, new
                    {
                        EventId = eventId,
                        TeamId = teamId,
                        Period = period
                    });
                }
                catch (Exception ex)
                {
                    throw new QueryStatisticException(ex.Message, ex);
                }
            }
        }

        public Task<Tuple<Statistic, Statistic>> GetByMatchAsync(int eventId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Statistic entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[SoccerTeamsEventStatistics]
                               SET [EventTimeStatisticId] = @EventTimeStatisticId
                                  ,[BallPossession] = @BallPossession
                                  ,[GoalAttempts] = @GoalAttempts
                                  ,[ShotsOnGoal] = @ShotsOnGoal
                                  ,[ShotsOffGoal] = @ShotsOffGoal
                                  ,[BlockedShots] = @BlockedShots
                                  ,[FreeKicks] = @FreeKicks
                                  ,[Offsides] = @Offsides
                                  ,[Throwin] = @Throwin
                                  ,[GoalkeeperSaves] = @GoalkeeperSaves
                                  ,[Fouls] = @Fouls
                                  ,[YellowCards] = @YellowCards
                                  ,[RedCards] = @RedCards
                                  ,[TotalPasses] = @TotalPasses
                                  ,[CompletedPasses] = @CompletedPasses
                                  ,[Trackles] = @Trackles
                                  ,[Attacks] = @Attacks
                                  ,[DangerousAttacks] = @DangerousAttacks
                             WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, entity);
                }
                catch (Exception ex)
                {
                    throw new UpdateStatisticException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<Statistic>> GetByCompetitionAsync(int competitionId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT * FROM [dbo].[Statistics] S
                                LEFT JOIN [dbo].[Events] E ON E.Id = S.EventId
                                LEFT JOIN [dbo].[Matches] M ON M.Id = E.MatchId
                                WHERE M.CompetitionId = @Id";
                try
                {
                    return await connection.QueryAsync<Statistic>(query, new { Id = competitionId });
                }
                catch (Exception ex)
                {
                    throw new QueryEventTimeStatisticException(ex.Message, ex);
                }
            }
        }
    }
}
