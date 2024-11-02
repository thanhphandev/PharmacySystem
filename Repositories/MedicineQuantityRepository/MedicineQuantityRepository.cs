using MySql.Data.MySqlClient;
using PharmacySystem.Models;
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
                    string query = "UPDATE medicine_quantity SET medicine_id = @MedicineId, quantity = @Quantity)";
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
    }
}
