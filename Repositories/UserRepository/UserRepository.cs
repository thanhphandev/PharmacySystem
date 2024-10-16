using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PharmacySystem.Repositories.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Thực thi các truy vấn
        public void AddUser(UserModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {

                string query = "INSERT INTO employee(username, password, full_name, birth_year) VALUES (@Username, @Password, @FullName, @BirthYear)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@BirthYear", user.Birth_year);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(string username)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM employee WHERE username = @Username";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using(var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM employee";
                using(var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserModel user = new UserModel();
                            user.Username = reader["username"].ToString();
                            user.FullName = reader["full_name"].ToString();
                            user.Birth_year = Convert.ToInt32(reader["birth_year"]);
                            user.Role = reader["role"].ToString();
                            users.Add(user);
                        }
                    }
                }
            }
            return users;
            
        }

        public UserModel GetUserByUsername(string username)
        {
            UserModel user = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT username, password, full_Name, birth_year, role  FROM employee WHERE username = @Username";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel
                            {
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Birth_year = Convert.ToInt32(reader["birth_year"]),
                                Role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }


        public void UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
