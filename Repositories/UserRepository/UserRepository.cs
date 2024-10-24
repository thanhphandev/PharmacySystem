using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PharmacySystem.Repositories.UserRepository
{
    public class UserRepository : BaseRepository, IUserRepository { 
    
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public void AddUser(UserModel user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {

                string query = "INSERT INTO employee(username, password, full_name, gender, email, phone, birth_date, address) VALUES (@Username, @Password, @FullName, @Gender, @Email, @Phone, @BOD, @Address)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@Gender", user.Gender);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@BOD", user.BoD);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    // Mở kết nối tới Server
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteUser(string username)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM employee WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", username);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using(var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM employee";
                using(var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserModel user = new UserModel
                            {
                                UserId = Convert.ToInt32(reader["id"]),
                                Username = reader["username"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Gender = reader["gender"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                BoD = Convert.ToDateTime(reader["birth_date"]),
                                Address = reader["address"].ToString()
                            };
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

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT id, username, password, full_Name, gender, email, phone, birth_date, address, role  FROM employee WHERE username = @Username";

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
                                UserId = Convert.ToInt32(reader["id"]),
                                Username = reader["username"].ToString(),
                                FullName = reader["full_name"].ToString(),
                                Password = reader["password"].ToString(),
                                Gender = reader["gender"].ToString(),
                                Email = reader["email"].ToString(),
                                Phone = reader["phone"].ToString(),
                                BoD = Convert.ToDateTime(reader["birth_date"]),
                                Address = reader["address"].ToString(),
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
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE employee " +
                               "SET username = @Username, " +
                               "full_name = @FullName, " +
                               "gender = @Gender, " +
                               "email = @Email, " +
                               "phone = @Phone, " +
                               "birth_date = @BirthDate, " +
                               "address = @Address, " +
                               "role = @Role " +
                               "WHERE id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@Id", user.UserId);
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@FullName", user.FullName);
                    command.Parameters.AddWithValue("@Gender", user.Gender);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Phone", user.Phone);
                    command.Parameters.AddWithValue("@BirthDate", (DateTime)user.BoD);
                    command.Parameters.AddWithValue("@Address", user.Address);
                    command.Parameters.AddWithValue("@Role", user.Role);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No user found with ID {user.UserId} to update.");
                    }
                }
            }
        }


    }
}
