using App.Domain.Exceptions;
using App.Domain.Exceptions.Statistic;
using App.Domain.Interfaces;
using App.Domain.Models;
using Dapper;
using System;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class EventTimeStatisticRepository : IEventTimeStatisticRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public EventTimeStatisticRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(EventTimeStatistic entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[EventTimeStatistics]
                                   ([Half]
                                   ,[EventId]
                                   ,[SoccerTeamId])
                             OUTPUT INSERTED.Id
                             VALUES
                                   (@Half
                                   ,@EventId
                                   ,@SoccerTeamId)";
                try
                {
                    return await connection.QuerySingleAsync<int>(query, entity);
                }
                catch (Exception ex)
                {
                    throw new AddEventTimeStatisticException(ex.Message, ex);
                }
            }
        }

        public async Task<EventTimeStatistic> GetAsync(int eventId, int half, int soccerTeamId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Half]
                                  ,[EventId]
                                  ,[SoccerTeamId]
                              FROM [dbo].[EventTimeStatistics]
                              WHERE Half = @half AND EventId = @eventId AND SoccerTeamId = @SoccerTeamId";
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<EventTimeStatistic>(query, new { Half = half, EventId = eventId, SoccerTeamId = soccerTeamId });
                }
                catch (Exception ex)
                {
                    throw new QueryEventTimeStatisticException(ex.Message, ex);
                }
            }
        }

    }
}
