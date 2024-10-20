using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PharmacySystem.Repositories.MedicineGroupRepository
{
    public class MedicineGroupRepository : BaseRepository, IMedicineGroup
    {
        public MedicineGroupRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddMedicineGroup(MedicineGroupModel medicineCategory)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    string query = "INSERT INTO medicine_group(group_code, group_name, group_content) VALUES (@GroupCode, @GroupName, @GroupDescription)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("GroupCode", medicineCategory.GroupCode);
                        command.Parameters.AddWithValue("GroupName", medicineCategory.GroupName);
                        command.Parameters.AddWithValue("Groupdescription", medicineCategory.Description);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the user: {ex.Message}");
                throw;
            }
            

        }

        public void DeleteMedicineGroup(string groupCode)
        {
           using (var connection = new MySqlConnection(connectionString))
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

        public List<MedicineGroupModel> GetAllMedicineGroups()
        {
            List<MedicineGroupModel> medicineGroups = new List<MedicineGroupModel>();
            using (var connection = new MySqlConnection(connectionString))
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
            MedicineGroupModel medicineGroup = new MedicineGroupModel();
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM medicine_group WHERE group_code = @GroupCode";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("GroupCode", groupCode);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            medicineGroup.GroupCode = reader["group_code"].ToString();
                            medicineGroup.GroupName = reader["group_name"].ToString();
                            medicineGroup.Description = reader["group_content"].ToString();
                        }
                    }
                }
            }
            return medicineGroup;
        }

        public void UpdateMedicineGroup(MedicineGroupModel medicineCategory)
        {
            throw new NotImplementedException();
        }
    }
}
