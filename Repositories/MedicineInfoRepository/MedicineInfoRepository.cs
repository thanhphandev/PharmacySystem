using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Repositories.MedicineInfoRepository
{
    public class MedicineInfoRepository : IMedicineInfoRepository
    {
        private readonly string _connectionString;
        public MedicineInfoRepository(string connectionString)
        {
            _connectionString = connectionString;

        }
        public void AddMedicineInfo(MedicineInfoModel medicineInfo)
        {
            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    
                    string query = @"INSERT INTO medicines (code, name, unit_type_id, price, image_url, 
                                                        description, ingredients, group_code)
                                    VALUES (@code, @name, @unitType, @price, @img, @content, @element, @groupCode)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", medicineInfo.Code);
                        cmd.Parameters.AddWithValue("@name", medicineInfo.Name);
                        cmd.Parameters.AddWithValue("@unitType", medicineInfo.UnitTypeId);
                        cmd.Parameters.AddWithValue("@price", medicineInfo.Price);
                        cmd.Parameters.AddWithValue("@img", medicineInfo.Image);
                        cmd.Parameters.AddWithValue("@content", medicineInfo.Description);
                        cmd.Parameters.AddWithValue("@element", medicineInfo.Ingredients);
                        cmd.Parameters.AddWithValue("@groupCode", medicineInfo.GroupCode);
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

        public void DeleteMedicineInfo(int medicineId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM medicines WHERE code = @code";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", medicineId);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<MedicineInfoModel> GetMedicinesByGroupCode(string groupCode)
        {
            try
            {
                List<MedicineInfoModel> medicines = new List<MedicineInfoModel>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM medicines WHERE group_code = @groupCode";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@groupCode", groupCode);
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicineInfoModel medicine = new MedicineInfoModel
                                {
                                    Code = reader["code"].ToString(),
                                    Name = reader["name"].ToString(),
                                    UnitTypeId = Convert.ToInt32(reader["unit_type_id"]),
                                    Price = Convert.ToDecimal(reader["medicine_price"]),
                                    Image = reader["medicine_img"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Ingredients = reader["ingredients"].ToString(),
                                    GroupCode = reader["group_code"].ToString()
                                };
                                medicines.Add(medicine);
                            }
                        }
                    }
                }
                return medicines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineInfoModel> GetAllMedicineInfo()
        {
            try
            {
                List<MedicineInfoModel> medicineInfos = new List<MedicineInfoModel>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM medicines";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                MedicineInfoModel medicineInfo = new MedicineInfoModel
                                {
                                    Code = reader["code"].ToString(),
                                    Name = reader["name"].ToString(),
                                    UnitTypeId = Convert.ToInt32(reader["unit_type_id"]),
                                    Price = Convert.ToDecimal(reader["medicine_price"]),
                                    Image = reader["medicine_img"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Ingredients = reader["ingredients"].ToString(),
                                    GroupCode = reader["group_code"].ToString()
                                };
                                medicineInfos.Add(medicineInfo);
                            }

                        }
                    }

                }
                return medicineInfos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public MedicineInfoModel GetMedicineInfoByMedicineName(string medicineName)
        {
            try
            {
                MedicineInfoModel medicineInfo = null;
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM medicines WHERE name = @name";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", medicineName);
                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                medicineInfo = new MedicineInfoModel
                                {
                                    Code = reader["code"].ToString(),
                                    Name = reader["name"].ToString(),
                                    UnitTypeId = Convert.ToInt32(reader["unit_type_id"]),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Image = reader["image_url"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Ingredients = reader["ingredients"].ToString(),
                                    GroupCode = reader["group_code"].ToString()
                                };
                            }
                        }
                    }
                }
                return medicineInfo;

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<string> GetAllMedicineName()
        {
            List<string> suggestions = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT name FROM medicines";
                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suggestions.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return suggestions;
        }

        public List<MedicineInfoModel> GetMedicinesByNameAndGroup(string searchName, string groupCode)
        {
            try
            {
                List<MedicineInfoModel> medicines = new List<MedicineInfoModel>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    // Define a base query to search by name, optionally filtering by group
                    string query = "SELECT * FROM medicines WHERE medicine_name LIKE @searchName";
                    if (!string.IsNullOrEmpty(groupCode))
                    {
                        query += " AND group_code = @groupCode";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Set parameters for the search query
                        cmd.Parameters.AddWithValue("@searchName", $"%{searchName}%");

                        if (!string.IsNullOrEmpty(groupCode))
                        {
                            cmd.Parameters.AddWithValue("@groupCode", groupCode);
                        }

                        connection.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Map each row to a MedicineInfoModel
                                MedicineInfoModel medicine = new MedicineInfoModel
                                {
                                    Code = reader["code"].ToString(),
                                    Name = reader["name"].ToString(),
                                    UnitTypeId = Convert.ToInt32(reader["unit_type"]),
                                    Price = Convert.ToDecimal(reader["medicine_price"]),
                                    Image = reader["image_url"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Ingredients = reader["ingredients"].ToString(),
                                    GroupCode = reader["group_code"].ToString()
                                };
                                medicines.Add(medicine);
                            }
                        }
                    }
                }
                return medicines;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving medicines by name and group: {ex.Message}");
            }
        }

        public void UpdateMedicineInfo(string medicineCode, MedicineInfoModel medicineInfo)
        {
            try
            {
                using(var connection = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE medicines
                                     SET code = @code,
                                         name = @name,
                                         unit_type_id = @unit,
                                         price = @price,
                                         image_url = @img,
                                         description = @content,
                                         ingredients = @element,
                                         group_code = @groupCode
                                     WHERE medicine_code = @medicineCode";
                    using(var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("code", medicineInfo.Code);
                        cmd.Parameters.AddWithValue("name", medicineInfo.Name);
                        cmd.Parameters.AddWithValue("unit", medicineInfo.UnitTypeId);
                        cmd.Parameters.AddWithValue("price", medicineInfo.Price);
                        cmd.Parameters.AddWithValue("img", medicineInfo.Image);
                        cmd.Parameters.AddWithValue("content", medicineInfo.Description);
                        cmd.Parameters.AddWithValue("element", medicineInfo.Ingredients);
                        cmd.Parameters.AddWithValue("groupCode", medicineInfo.GroupCode);
                        cmd.Parameters.AddWithValue("medicineCode", medicineCode);
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
    }
}
