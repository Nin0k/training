using DAL.Common;
using Entitiens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.SQL
{
    public class SQLAwardsDAL : IAwardDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public IEnumerable<Awards> GetAllAwards()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Awards_GetAllAwards";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                
                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Awards award = new Awards(reader["Title"] as string);

                    award.IDAward = (Guid)reader["IDAward"];
                   
                    yield return award;
                }
            }
        }
        public void DeleteAward(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Awards_DeleteAward";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();
                command.ExecuteReader();
            }
        }

        public Awards GetAwardByID(Guid id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Awards_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Awards award = new Awards(reader["Title"] as string);
                    award.IDAward = (Guid)reader["IDAward"];
                    
                    return award;
                }

                throw new InvalidOperationException("Cannot find Student with ID = " + id);
            }
        }

        public void SaveAward(Awards award)
        {
            Awards oldAward = GetAwardByID(award.IDAward);
            if (oldAward.IDAward == award.IDAward)
            {
                using (SqlConnection _connection = new SqlConnection(_connectionString))
                {
                    var stProc = "Awards_UpdateAward";

                    var command = new SqlCommand(stProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@ID", award.IDAward);
                    command.Parameters.AddWithValue("@Title", award.Title);
                   
                    _connection.Open();
                    command.ExecuteReader();
                }
            }
            else
            {
                using (SqlConnection _connection = new SqlConnection(_connectionString))
                {
                    var stProc = "Awards_SaveAward";

                    var command = new SqlCommand(stProc, _connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@ID", award.IDAward);
                    command.Parameters.AddWithValue("@Title", award.Title);

                    _connection.Open();
                    command.ExecuteReader();
                }
            }
        }
    }
}
