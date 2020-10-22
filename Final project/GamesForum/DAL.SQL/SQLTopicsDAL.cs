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
    public class SQLTopicsDAL : ITopicsDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;
        public IEnumerable<Topic> GetAllByIdForum(Guid idForum)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Topic_GetByIdForum";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@idForum", idForum);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Topic topics = new Topic(reader["name"] as string, idForum, (bool)reader["important"]);
                    topics.IDTopic = (Guid)reader["id_topic"];

                    yield return topics;
                }

            }
        }

        public Topic GetTopicByID(Guid idTopic)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Topic_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", idTopic);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Topic topic = new Topic(reader["name"] as string, (Guid)reader["id_forum"], (bool)reader["important"]);
                    topic.IDTopic = idTopic;
                   
                    return topic;
                }

                throw new InvalidOperationException("Cannot find topic with ID = " + idTopic);
            }
        }
    }
}
