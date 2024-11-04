using MySql.Data.MySqlClient;
using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineRepository
{
    public class MedicineRepository : IMedicineRepository
    {
        private readonly string _connectionString;
        public MedicineRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddMedicine(MedicineModel medicine)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO medicine (medicine_expire_date, medicine_code, supplier_id)
                             VALUES (@expireDate, @code, @supplierId);
                             SELECT LAST_INSERT_ID();";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@expireDate", medicine.ExpireDate);
                        cmd.Parameters.AddWithValue("@code", medicine.MedicineCode);
                        cmd.Parameters.AddWithValue("@supplierId", medicine.SupplierId);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void DeleteMedicine(int id)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM medicine WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetMedicineIdByEarliestExpiry(string medicineCode)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"SELECT id FROM medicine 
                             WHERE medicine_code = @MedicineCode 
                             ORDER BY medicine_expire_date ASC 
                             LIMIT 1";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("MedicineCode", medicineCode);

                        connection.Open();
                        var result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int medicineId))
                        {
                            return medicineId;
                        }
                        else
                        {
                            throw new Exception("No medicine found with the specified code and expiration date.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching medicine with nearest expiration date: " + ex.Message);
            }
        }

    }
}
