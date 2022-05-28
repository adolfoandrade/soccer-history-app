using App.Domain.Exceptions.SoccerTeam;
using App.Domain.Interfaces;
using App.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infra.Data.Repository
{
    public class SoccerTeamRepository : ISoccerTeamRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public SoccerTeamRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(SoccerTeam soccerTeam)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[SoccerTeams]
                                   ([Name]
                                   ,[Country]
                                   ,[Image]
                                   ,[Created]
                                   ,[Updated]
                                   ,[ColorTheme]
                                   ,[SecondColorTheme])
                             VALUES
                                   (@Name
                                   ,@Country
                                   ,@Image
                                   ,@Created
                                   ,@Updated
                                   ,@ColorTheme
                                   ,@SecondColorTheme)";
                try
                {
                    return await connection.ExecuteAsync(query, soccerTeam);
                }
                catch (Exception ex)
                {
                    throw new AddSoccerTeamException(ex.Message, ex);
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"DELETE FROM [dbo].[SoccerTeams] WHERE Id = @id";
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new DeleteSoccerTeamException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<SoccerTeam>> FilterAsync(string filter)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Name]
                                  ,[Country]
                                  ,[Image]
                                  ,[Created]
                                  ,[Updated]
                                  ,[ColorTheme]
                                  ,[SecondColorTheme]
                              FROM [dbo].[SoccerTeams]
                              WHERE [Name] LIKE '%{filter}%'";
                try
                {
                    return await connection.QueryAsync<SoccerTeam>(query);
                }
                catch (Exception ex)
                {
                    throw new QuerySoccerTeamException(ex.Message, ex);
                }
            }
        }

        public async Task<SoccerTeam> GetAsync(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Name]
                                  ,[Country]
                                  ,[Image]
                                  ,[ColorTheme]
                                  ,[SecondColorTheme]
                                  ,[Created]
                                  ,[Updated]
                                  ,[ColorTheme]
                                  ,[SecondColorTheme]
                              FROM [dbo].[SoccerTeams]
                              WHERE [Id] = @Id";
                try
                {
                    return await connection.QueryFirstAsync<SoccerTeam>(query, new { Id = id });
                }
                catch (Exception ex)
                {
                    throw new QuerySoccerTeamException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<SoccerTeam>> GetAsync()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[Name]
                                  ,[Country]
                                  ,[Image]
                                  ,[Created]
                                  ,[Updated]
                                  ,[ColorTheme]
                                  ,[SecondColorTheme]
                              FROM [dbo].[SoccerTeams]";
                try
                {
                    return await connection.QueryAsync<SoccerTeam>(query);
                }
                catch (Exception ex)
                {
                    throw new QuerySoccerTeamException(ex.Message, ex);
                }
            }
        }

        public async Task<int> UpdateAsync(SoccerTeam soccerTeam)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[SoccerTeams]
                               SET [Name] = @Name
                                  ,[Country] = @Country
                                  ,[Image] = @Image
                                  ,[Updated] = @Updated
                                  ,[ColorTheme] = @ColorTheme
                                  ,[SecondColorTheme] = @SecondColorTheme
                             WHERE [Id] = @Id";
                try
                {
                    return await connection.ExecuteAsync(query, soccerTeam);
                }
                catch (Exception ex)
                {
                    throw new UpdateSoccerTeamException(ex.Message, ex);
                }
            }
        }
    }
}
