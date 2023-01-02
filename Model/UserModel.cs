using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Common.Cache;

namespace Model {
    public class UserModel : ConnectionToSql {
        public bool Login(string user, string password) {
            using (var connection = GetConnection()) {
                connection.Open();
                using (var command = new SqlCommand()) {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM users WHERE loginName=@user AND password=@password";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@password", password);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            UserLoginCache.UserID = reader.GetInt32(0);
                            UserLoginCache.FirstName = reader.GetString(3);
                            UserLoginCache.LastName = reader.GetString(4);
                            UserLoginCache.Cargo = reader.GetString(5);
                            UserLoginCache.Status = reader.GetString(6);
                            UserLoginCache.Email = reader.GetString(7);
                        }
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        }
    }
}
