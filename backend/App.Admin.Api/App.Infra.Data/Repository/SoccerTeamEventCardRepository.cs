using App.Domain.Exceptions.SoccerTeamEventCard;
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
    public class SoccerTeamEventCardRepository : ISoccerTeamEventCardRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SoccerTeamEventCardRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(SoccerTeamEventCard entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[CardsStatistics]
                                       ([EventTimeStatisticId]
                                       ,[Minute]
                                       ,[Player]
                                       ,[Color])
                                 VALUES
                                       (@EventTimeStatisticId
                                       ,@Minute
                                       ,@Player
                                       ,@Color)";
                try
                {
                    return await connection.ExecuteAsync(query, entity);
                }
                catch (Exception ex)
                {
                    throw new AddSoccerTeamEventCardException(ex.Message, ex);
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[CardsStatistics] WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new DeleteSoccerTeamEventCardException(ex.Message, ex);
                }
            }
        }

        public async Task<SoccerTeamEventCard> GetAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"SELECT [Id]
                                  ,[SoccerTeamId]
                                  ,[Minute]
                                  ,[EventId]
                                  ,[Player]
                                  ,[Color]
                              FROM [dbo].[CardsStatistics]
                            WHERE [Id] = @Id";
                try
                {
                    return await connection.QueryFirstAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new QuerySoccerTeamEventCardException(ex.Message, ex);
                }
            }
        }

        public async Task<int> UpdateAsync(SoccerTeamEventCard entity)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[CardsStatistics]
                               SET [SoccerTeamId] = @SoccerTeamId
                                  ,[Minute] = @Minute
                                  ,[EventId] = @EventId
                                  ,[Player] = @Player
                                  ,[Color] = @Color
                             WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, entity);
                }
                catch (Exception ex)
                {
                    throw new UpdateSoccerTeamEventCardException(ex.Message, ex);
                }
            }
        }
    }
}
