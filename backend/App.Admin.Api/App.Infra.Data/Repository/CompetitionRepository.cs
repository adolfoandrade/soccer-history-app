using App.Domain.Exceptions.Competition;
using App.Domain.Interfaces;
using App.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public CompetitionRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(Competition competition)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[Competitions]
                                ([Name]
                                ,[Country]
                                ,[Image]
                                ,[Created]
                                ,[Updated])
                            OUTPUT INSERTED.Id
                            VALUES
                                (@Name
                                ,@Country
                                ,@Image
                                ,@Created
                                ,@Updated)";
                try
                {
                    return await connection.QueryFirstAsync<int>(query, new
                    {
                        Name = competition.Name,
                        Country = competition.Country,
                        Image = competition.Image,
                        Created = competition.Created,
                        Updated = competition.Updated,
                    });
                }
                catch (Exception ex)
                {
                    throw new AddCompetitionException(ex.Message, ex);
                }

            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[Competitions] WHERE Id = @id";
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new DeleteCompetitionException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<Competition>> GetBySeasonAsync(string season)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Name]
                                  ,[Country]
                                  ,[Image]
                                  ,[Year]
                                  ,[Created]
                                  ,[Updated]
                              FROM [dbo].[Competitions]
                              WHERE [Year] LIKE '%{season}%'";
                try
                {
                    return await connection.QueryAsync<Competition>(query);
                }
                catch (Exception ex)
                {
                    throw new QueryCompetitionBySeasonException(ex.Message, ex);
                }
            }
        }

        public async Task<int> UpdateAsync(Competition competition)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[Competitions]
                               SET [Name] = @Name
                                  ,[Country] = @Country
                                  ,[Image] = @Image
                                  ,[Year] = @Year
                                  ,[Updated] = @Updated
                             WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, competition);
                }
                catch (Exception ex)
                {
                    throw new UpdateCompetitionException(ex.Message, ex);
                }
            }
        }
    }
}
