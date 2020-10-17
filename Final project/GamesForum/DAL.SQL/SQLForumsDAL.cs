using DAL.Common;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SQL
{
    public class SQLForumsDAL : IForumsDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public IEnumerable<Forum> GetAllForums()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Forums_GetAllForums";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Forum forum = new Forum(reader["name"] as string);

                    forum.IDForum = (Guid)reader["id_forum"];


                    yield return forum;
                }
            }
        }
    }
}
