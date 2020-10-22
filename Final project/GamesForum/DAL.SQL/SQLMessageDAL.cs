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
   public class SQLMessageDAL : IMessageDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["mysql"].ConnectionString;

        public IEnumerable<Message> GetMassagesByIdTopic(Guid idTopic)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Massages_GetByMassagesWhisIdTopic";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", idTopic);

                _connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    Message message = new Message(reader["text"] as string, (Guid)reader["id_user"], idTopic);
                    message.IDMessage = (Guid)reader["id_massages"];
                    message.Reputation = (int)reader["reputation"];
                    message.Date = (DateTime)reader["data"];
                       
                    yield return message;
                }

            }
        }
        public Message GetMessageByID(Guid id) 
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Message_GetById";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@id", id);

                _connection.Open();

                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    Message message = new Message(reader["text"] as string, (Guid)reader["id_user"], (Guid)reader["id_topic"]);
                    message.IDMessage = id;
                    message.Reputation = (int)reader["reputation"];
                    message.Date = (DateTime)reader["data"];

                    return message;
                }

                throw new InvalidOperationException("Cannot find message with ID = " + id);
            }
        }

        public void EditMessang(Message messange)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                var stProc = "Message_UpdateMessang";

                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
             
                command.Parameters.AddWithValue("@id_messange", messange.IDMessage);
                command.Parameters.AddWithValue("@text", messange.Text);
                command.Parameters.AddWithValue("@reputation", messange.Reputation);

                _connection.Open();
                command.ExecuteReader();
            }
           
        }
    }
}
