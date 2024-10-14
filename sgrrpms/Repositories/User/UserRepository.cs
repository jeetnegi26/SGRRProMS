using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRepositoryData
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public User GetUserByUsername(string username)
        {
            User user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUserByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Add input parameter for the stored procedure
                    cmd.Parameters.Add(new SqlParameter("@Username", username));
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt32(reader["UserId"]),
                                Name = reader["Username"].ToString(),
                                HashPassword = reader["Password"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}
