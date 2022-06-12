using App.Domain.Exceptions.ApiValueReference;
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
    public class ApiValueReferenceRepository : IApiValueReferenceRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ApiValueReferenceRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> AddAsync(ApiValueReference reference)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"INSERT INTO [dbo].[APIValuesReferences]
                                   ([TableReference]
                                   ,[ApiName]
                                   ,[ApiId]
                                   ,[AppId])
                             VALUES
                                   (@TableReference
                                   ,@ApiName
                                   ,@ApiId
                                   ,@AppId)";
                try
                {
                    return await connection.ExecuteAsync(query, reference);
                }
                catch (Exception ex)
                {
                    throw new AddApiValueReferenceException(ex.Message, ex);
                }

            }
        }

        public async Task<int> UpdateAsync(ApiValueReference reference)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = @"UPDATE [dbo].[APIValuesReferences]
                               SET [TableReference] = @TableReference
                                  ,[ApiName] = @ApiName
                                  ,[ApiId] = @ApiId
                                  ,[AppId] = @AppId
                             WHERE [AppId] = @AppId";
                try
                {
                    return await connection.ExecuteAsync(query, reference);
                }
                catch (Exception ex)
                {
                    throw new AddApiValueReferenceException(ex.Message, ex);
                }
            }
        }

        public async Task<ApiValueReference> GetByApiIdAsync(string table, int apiId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[TableReference]
                                  ,[ApiName]
                                  ,[ApiId]
                                  ,[AppId]
                              FROM [dbo].[APIValuesReferences]
                              WHERE [TableReference] = @Table AND [ApiId] = @ApiId";
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<ApiValueReference>(query, new { Table = table, ApiId = apiId });
                }
                catch (Exception ex)
                {
                    throw new QueryApiValueReferenceException(ex.Message, ex);
                }
            }
        }

        public async Task<IEnumerable<ApiValueReference>> GetByTableNameAsync(string table)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[TableReference]
                                  ,[ApiName]
                                  ,[ApiId]
                                  ,[AppId]
                              FROM [dbo].[APIValuesReferences]
                              WHERE [TableReference] = @Table";
                try
                {
                    return await connection.QueryAsync<ApiValueReference>(query, new { Table = table });
                }
                catch (Exception ex)
                {
                    throw new QueryApiValueReferenceException(ex.Message, ex);
                }
            }
        }

        public async Task<ApiValueReference> GetByAppIdAsync(string table, int appId)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                var query = $@"SELECT [Id]
                                  ,[TableReference]
                                  ,[ApiName]
                                  ,[ApiId]
                                  ,[AppId]
                              FROM [dbo].[APIValuesReferences]
                              WHERE [TableReference] = @Table AND [AppId] = @AppId";
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<ApiValueReference>(query, new { Table = table, AppId = appId });
                }
                catch (Exception ex)
                {
                    throw new QueryApiValueReferenceException(ex.Message, ex);
                }
            }
        }
    }
}
