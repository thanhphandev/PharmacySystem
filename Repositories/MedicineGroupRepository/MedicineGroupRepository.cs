using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "INSERT INTO medicine_group(group_code, group_name, group_content) VALUES (@GroupCode, @GroupName, @GroupDescription)";
                    using (var command = new MySqlCommand(query, connection))
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
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "DELETE FROM medicine_group WHERE group_code =@GroupCode";
                    using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM medicine_group";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using(var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MedicineGroupModel medicineGroup = new MedicineGroupModel
                            {
                                GroupCode = reader["group_code"].ToString(),
                                GroupName = reader["group_name"].ToString(),
                                Description = reader["group_content"].ToString()
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
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "SELECT group_code, group_name, group_content FROM medicine_group WHERE group_code = @GroupCode";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("GroupCode", groupCode);
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                medicineGroup = new MedicineGroupModel
                                {
                                    GroupCode = reader["group_code"].ToString(),
                                    GroupName = reader["group_name"].ToString(),
                                    Description = reader["group_content"].ToString()
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
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"UPDATE medicine_group 
                             SET group_code = @NewGroupCode, group_name = @GroupName, group_content = @GroupContent 
                             WHERE group_code = @OldGroupCode";

                    using (var command = new MySqlCommand(query, connection))
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
