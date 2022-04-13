using App.Domain.Exceptions.SoccerEvent;
using App.Domain.Interfaces;
using App.Models;
using Dapper;
using System;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public MatchRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(Match match)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[Matches]
                                   ([Number]
                                   ,[Letter]
                                   ,[Stage]
                                   ,[CompetitionId])
                             VALUES
                                   (@Number
                                   ,@Letter
                                   ,@Stage
                                   ,@CompetitionId)";
                try
                {
                    return await connection.ExecuteAsync(query, match);
                }
                catch (Exception ex)
                {
                    throw new AddMatchException(ex.Message, ex);
                }
            }
        }

        public async Task<Match> GetByMatchNumerAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Number]
                                  ,[Letter]
                                  ,[Stage]
                                  ,[CompetitionId]
                              FROM [dbo].[Matches]
                              WHERE [Number] = @Id";
                try
                {
                    return await connection.QueryFirstAsync<Match>(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new QueryMatchException(ex.Message, ex);
                }
            }
        }

        public async Task<Match> GetAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Number]
                                  ,[Letter]
                                  ,[Stage]
                                  ,[CompetitionId]
                              FROM [dbo].[Matches]
                              WHERE [Id] = @Id";
                try
                {
                    return await connection.QueryFirstAsync<Match>(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new QueryMatchException(ex.Message, ex);
                }
            }
        }
    }
}
