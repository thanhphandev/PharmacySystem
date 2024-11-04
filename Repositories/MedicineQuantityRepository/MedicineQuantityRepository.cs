using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineQuantityRepository
{
    public class MedicineQuantityRepository : IMedicineQuantityRepository
    {
        private readonly string _connectionString;
        public MedicineQuantityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "INSERT INTO medicine_quantity(medicine_id, quantity) VALUES (@MedicineId, @Quantity)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("MedicineId", medicineId);
                        command.Parameters.AddWithValue("Quantity", quantity);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void UpdateMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "UPDATE medicine_quantity SET quantity = @Quantity WHERE medicine_id = @MedicineId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("MedicineId", medicineId);
                        command.Parameters.AddWithValue("Quantity", quantity);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public int GetCurrentQuantity(int medicineId)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "SELECT quantity FROM medicine_quantity WHERE medicine_id = @MedicineId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("MedicineId", medicineId);
                        connection.Open();
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            int quantity = Convert.ToInt32(reader["quantity"]);
                            return quantity;
                        }
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
