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

        public List<MedicineProductModel> GetAllMedicineProduct()
        {
            List<MedicineProductModel> medicineProductModels = new List<MedicineProductModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"
                SELECT 
                    mi.medicine_code,
                    mi.medicine_name,
                    ut.unit_name as medicine_unit,
                    mi.medicine_price as price,
                    COALESCE(SUM(mq.quantity), 0) as total_quantity,
                    mi.medicine_img as image_url
                FROM medicine_info mi
                LEFT JOIN medicine m ON mi.medicine_code = m.medicine_code
                LEFT JOIN medicine_quantity mq ON m.id = mq.medicine_id
                LEFT JOIN unit_type ut ON mi.unit_type = ut.id
                GROUP BY 
                    mi.medicine_code,
                    mi.medicine_name,
                    ut.unit_name,
                    mi.medicine_price,
                    mi.medicine_img
                HAVING total_quantity > 0";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicineProductModel medicineProductModel = new MedicineProductModel
                                {
                                    MedicineCode = reader["medicine_code"].ToString(),
                                    MedicineName = reader["medicine_name"].ToString(),
                                    MedicineUnit = reader["medicine_unit"].ToString(),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Quantity = reader["total_quantity"] != DBNull.Value ? Convert.ToInt32(reader["total_quantity"]) : 0,
                                    ImageUrl = reader["image_url"].ToString(),
                                  
                                };
                                medicineProductModels.Add(medicineProductModel);
                            }
                        }
                    }
                }
                return medicineProductModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineProductModel> GetMedicineProductsByGroupCode(string groupCode)
        {
            List<MedicineProductModel> medicineProductModels = new List<MedicineProductModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"
                                SELECT 
                                    mi.medicine_code,
                                    mi.medicine_name,
                                    ut.unit_name AS medicine_unit,
                                    mi.medicine_price AS price,
                                    COALESCE(SUM(mq.quantity), 0) AS total_quantity,
                                    mi.medicine_img AS image_url
                                FROM 
                                    medicine_info mi
                                LEFT JOIN 
                                    medicine m ON mi.medicine_code = m.medicine_code
                                LEFT JOIN 
                                    medicine_quantity mq ON m.id = mq.medicine_id
                                LEFT JOIN 
                                    unit_type ut ON mi.unit_type = ut.id
                                WHERE 
                                    mi.group_code = @GroupCode
                                GROUP BY 
                                    mi.medicine_code,
                                    mi.medicine_name,
                                    ut.unit_name,
                                    mi.medicine_price,
                                    mi.medicine_img
                                HAVING 
                                    total_quantity > 0";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroupCode", groupCode);

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicineProductModel medicineProductModel = new MedicineProductModel
                                {
                                    MedicineCode = reader["medicine_code"].ToString(),
                                    MedicineName = reader["medicine_name"].ToString(),
                                    MedicineUnit = reader["medicine_unit"].ToString(),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Quantity = reader["total_quantity"] != DBNull.Value ? Convert.ToInt32(reader["total_quantity"]) : 0,
                                    ImageUrl = reader["image_url"].ToString(),
                                    
                                };
                                medicineProductModels.Add(medicineProductModel);
                            }
                        }
                    }
                }
                return medicineProductModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineProductModel> GetMedicineProductsByNameAndGroup(string searchText, string groupCode)
        {
            List<MedicineProductModel> medicineProductModels = new List<MedicineProductModel>();
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"
                                SELECT 
                                    mi.medicine_code,
                                    mi.medicine_name,
                                    ut.unit_name AS medicine_unit,
                                    mi.medicine_price AS price,
                                    COALESCE(SUM(mq.quantity), 0) AS total_quantity,
                                    mi.medicine_img AS image_url
                                FROM 
                                    medicine_info mi
                                LEFT JOIN 
                                    medicine m ON mi.medicine_code = m.medicine_code
                                LEFT JOIN 
                                    medicine_quantity mq ON m.id = mq.medicine_id
                                LEFT JOIN 
                                    unit_type ut ON mi.unit_type = ut.id
                                WHERE 
                                    (@GroupCode IS NULL OR mi.group_code = @GroupCode) 
                                    AND mi.medicine_name LIKE @SearchText
                                GROUP BY 
                                    mi.medicine_code,
                                    mi.medicine_name,
                                    ut.unit_name,
                                    mi.medicine_price,
                                    mi.medicine_img
                                HAVING 
                                    total_quantity > 0";  // Ensure we only return products with quantity > 0

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroupCode", (object)groupCode ?? DBNull.Value); // Handle null groupCode
                        command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%"); // Wildcard search

                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicineProductModel medicineProductModel = new MedicineProductModel
                                {
                                    MedicineCode = reader["medicine_code"].ToString(),
                                    MedicineName = reader["medicine_name"].ToString(),
                                    MedicineUnit = reader["medicine_unit"].ToString(),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Quantity = Convert.ToInt32(reader["total_quantity"]),
                                    ImageUrl = reader["image_url"].ToString(),
                                };
                                medicineProductModels.Add(medicineProductModel);
                            }
                        }
                    }
                }
                return medicineProductModels;
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
