using App.Domain.Exceptions.Statistic;
using App.Domain.Interfaces;
using App.Domain.Models;
using Dapper;
using System;
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
                var query = @"INSERT INTO [dbo].[EventStatistics]
                                   ([EventTimeStatisticId]
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
                                   (@EventTimeStatisticId
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
    }
}
