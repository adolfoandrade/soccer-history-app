using App.Domain.Exceptions.SoccerTeamEventGoal;
using App.Domain.Interfaces;
using App.Domain.Models;
using Dapper;
using System;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class SoccerTeamEventGolRepository : ISoccerTeamEventGolRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SoccerTeamEventGolRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(SoccerTeamEventGol entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[GoalsStatistics]
                                   ([Assist]
                                   ,[Minute]
                                   ,[EventTimeStatisticId]
                                   ,[Player])
                             VALUES
                                   (@Assist
                                   ,@Minute
                                   ,@EventTimeStatisticId
                                   ,@Player)";
                try
                {
                    return await connection.ExecuteAsync(query, entity);
                }
                catch (Exception ex)
                {
                    throw new AddSoccerTeamEventGoalsException(ex.Message, ex);
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[GoalsStatistics] WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new DeleteSoccerTeamEventGoalsException(ex.Message, ex);
                }
            }
        }

        public async Task<int> UpdateAsync(SoccerTeamEventGol entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[GoalsStatistics]
                               SET [SoccerTeamId] = @SoccerTeamId
                                  ,[Minute] = @Minute
                                  ,[EventId] = @EventId
                                  ,[Player] = @Player
                             WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, entity);
                }
                catch (Exception ex)
                {
                    throw new UpdateSoccerTeamEventGoalsException(ex.Message, ex);
                }
            }
        }
    }
}
