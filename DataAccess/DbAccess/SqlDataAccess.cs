using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
//talk to sql through dapper
namespace DataAccess.DbAccess
{
public class SqlDataAccess :ISqlDataAccess
{
       
    private readonly IConfiguration _config;
    public  SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

        [Obsolete]
        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(storedProcedure, parameters, 
                commandType: CommandType.StoredProcedure);

        }

        [Obsolete]
        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters, 
                commandType: CommandType.StoredProcedure);

        }
    }
}
