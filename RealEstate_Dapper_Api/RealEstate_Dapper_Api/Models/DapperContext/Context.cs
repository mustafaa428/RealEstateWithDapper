using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connecationstring;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connecationstring = _configuration.GetConnectionString("Connection");
        }
        public IDbConnection CreateConnection()=>new SqlConnection(_connecationstring);
        

    }
}
