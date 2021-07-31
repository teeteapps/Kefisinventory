using Dapper;
using DBL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL.Repository
{
    public class SecurityRepository:BaseRepository,ISecurityRepository
    {
        public SecurityRepository(string connectionString) : base(connectionString)
        {
        }
        public BaseEntity Login(string userName)
        {
            using (var connection = new SqlConnection(_connString))
            {
                connection.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Emailaddress", userName);

                return connection.Query<BaseEntity>("Usp_VerifyUser", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
