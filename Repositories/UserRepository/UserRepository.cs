using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PharmacySystem.Repositories.UserRepository
{
    public class UserRepository :  IUserRepository { 
    
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        
        public async Task AddUser(UserModel user)
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
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        
        public async Task DeleteUser(string username)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM employee WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", username);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();
            using(var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM employee";
                using(var command = new MySqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using(var reader = await command.ExecuteReaderAsync())
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

        public async Task<UserModel> GetUserByUsername(string username)
        {
            UserModel user = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT id, username, password, full_Name, gender, email, phone, birth_date, address, role  FROM employee WHERE username = @Username";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
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


        public async Task UpdateUser(UserModel user)
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

                    await connection.OpenAsync();

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException($"No user found with ID {user.UserId} to update.");
                    }
                }
            }
        }


        public async Task<List<RoleCountModel>> GetEmployeeCountByRole()
        {
            var roleCounts = new List<RoleCountModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT role, COUNT(*) AS count FROM employee GROUP BY role";

                using (var command = new MySqlCommand(query, connection))
                {
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            roleCounts.Add(new RoleCountModel
                            {
                                Role = reader["role"].ToString(),
                                Count = Convert.ToInt32(reader["count"])
                            });
                        }
                    }
                }
            }

            return roleCounts;
        }



    }
}
