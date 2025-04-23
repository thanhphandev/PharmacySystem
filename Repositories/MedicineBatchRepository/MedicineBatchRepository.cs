using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineRepository
{
    public class MedicineBatchRepository : IMedicineBatchRepository
    {
        private readonly string _connectionString;
        public MedicineBatchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddMedicineBatch(MedicineBatch medicine)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO medicine_batches (medicine_code, supplier_id, expire_date, quantity)
                             VALUES (@code, @supplierId, expire_date, quantity);
                             SELECT LAST_INSERT_ID();";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", medicine.MedicineCode);
                        cmd.Parameters.AddWithValue("@supplierId", medicine.SupplierID);
                        cmd.Parameters.AddWithValue("@expireDate", medicine.ExpireDate);
                        cmd.Parameters.AddWithValue("@quantity", medicine.Quantity);
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"
                SELECT 
                    mi.code,
                    mi.name,
                    ut.name as medicine_unit,
                    mi.price,
                    mi.image_url,
                    m.quantity

                FROM medicines mi
                LEFT JOIN medicine_batches m ON mi.code = m.medicine_code
                LEFT JOIN unit_type ut ON mi.unit_type_id = ut.id
                GROUP BY 
                    mi.code,
                    mi.name,
                    ut.name,
                    mi.price,
                    mi.image_url
                HAVING total_quantity > 0";

                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicineProductModel medicineProductModel = new MedicineProductModel
                                {
                                    MedicineCode = reader["code"].ToString(),
                                    MedicineName = reader["name"].ToString(),
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
                using (var connection = new SqlConnection(_connectionString))
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

                    using (var command = new SqlCommand(query, connection))
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
                using (var connection = new SqlConnection(_connectionString))
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

                    using (var command = new SqlCommand(query, connection))
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


        public void DeleteMedicineBatch(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM medicine_batches WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
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
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"SELECT id FROM medicine_batches 
                             WHERE code = @MedicineCode 
                             ORDER BY medicine_expire_date ASC 
                             LIMIT 1";

                    using (var command = new SqlCommand(query, connection))
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

        public void AddMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE medicine_batches SET (@MedicineId, @Quantity) WHERE (id: )";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("MedicineId", medicineId);
                        command.Parameters.AddWithValue("Quantity", quantity);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "UPDATE medicine_batches SET quantity = @Quantity WHERE medicine_id = @MedicineId";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("MedicineId", medicineId);
                        command.Parameters.AddWithValue("Quantity", quantity);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public int GetCurrentQuantity(int medicineId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT quantity FROM medicine_quantity WHERE medicine_id = @MedicineId";
                    using (var command = new SqlCommand(query, connection))
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
