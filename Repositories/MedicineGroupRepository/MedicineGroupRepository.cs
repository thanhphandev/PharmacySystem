using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PharmacySystem.Repositories.MedicineGroupRepository
{
    public class MedicineGroupRepository :  IMedicineGroupRepository
    {
        private readonly string _connectionString;
        public MedicineGroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddMedicineGroup(MedicineGroupModel medicineCategory)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO medicine_groups(code, name, description) VALUES (@GroupCode, @GroupName, @GroupDescription)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("GroupCode", medicineCategory.GroupCode);
                        command.Parameters.AddWithValue("GroupName", medicineCategory.GroupName);
                        command.Parameters.AddWithValue("GroupDescription", medicineCategory.Description);

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

        public void DeleteMedicineGroup(string groupCode)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM medicine_groups WHERE code = @GroupCode";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("GroupCode", groupCode);
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

        public List<MedicineGroupModel> GetAllMedicineGroups()
        {
            List<MedicineGroupModel> medicineGroups = new List<MedicineGroupModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM medicine_groups";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MedicineGroupModel medicineGroup = new MedicineGroupModel
                            {
                                GroupCode = reader["code"].ToString(),
                                GroupName = reader["name"].ToString(),
                                Description = reader["description"].ToString()
                            };
                            medicineGroups.Add(medicineGroup);

                        }
                    }
                }
            }
            return medicineGroups;
        }

        public MedicineGroupModel GetMedicineGroupByCode(string groupCode)
        {
            try 
            {
                MedicineGroupModel medicineGroup = null;
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT code, name, description FROM medicine_groups WHERE code = @GroupCode";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("GroupCode", groupCode);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                medicineGroup = new MedicineGroupModel
                                {
                                    GroupCode = reader["code"].ToString(),
                                    GroupName = reader["name"].ToString(),
                                    Description = reader["description"].ToString()
                                };
                            }
                        }
                    }
                }
                return medicineGroup;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void UpdateMedicineGroup(string oldGroupCode, MedicineGroupModel updatedMedicineGroup)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = @"UPDATE medicine_groups 
                             SET code = @NewGroupCode, name = @GroupName, description = @GroupContent 
                             WHERE code = @OldGroupCode";

                    using (var command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@NewGroupCode", updatedMedicineGroup.GroupCode);
                        command.Parameters.AddWithValue("@GroupName", updatedMedicineGroup.GroupName);
                        command.Parameters.AddWithValue("@GroupContent", updatedMedicineGroup.Description);

                        
                        command.Parameters.AddWithValue("@OldGroupCode", oldGroupCode);

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


    }
}
