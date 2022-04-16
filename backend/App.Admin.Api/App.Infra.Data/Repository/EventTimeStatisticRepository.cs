using App.Domain.Exceptions;
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
    }
}
