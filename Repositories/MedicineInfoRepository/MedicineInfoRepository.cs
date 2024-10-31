﻿using MySql.Data.MySqlClient;
using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineInfoRepository
{
    public class MedicineInfoRepository : IMedicineInfoRepository
    {
        private readonly string _connectionString;
        public MedicineInfoRepository(string connetionString)
        {
            _connectionString = connetionString;

        }
        public void AddMedicineInfo(MedicineInfoModel medicineInfo)
        {
            try
            {
                using(var connection = new MySqlConnection(_connectionString))
                {
                    
                    string query = @"INSERT INTO medicine_info (medicine_code, medicine_name, unit_type, medicine_price, medicine_img, 
                                                        medicine_content, medicine_element, group_code)
                                    VALUES (@code, @name, @unitType, @price, @img, @content, @element, @groupCode)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", medicineInfo.MedicineCode);
                        cmd.Parameters.AddWithValue("@name", medicineInfo.MedicineName);
                        cmd.Parameters.AddWithValue("@unitType", medicineInfo.UnitType);
                        cmd.Parameters.AddWithValue("@price", medicineInfo.MedicinePrice);
                        cmd.Parameters.AddWithValue("@img", medicineInfo.MedicineImage);
                        cmd.Parameters.AddWithValue("@content", medicineInfo.MedicineContent);
                        cmd.Parameters.AddWithValue("@element", medicineInfo.MedicineElement);
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
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"DELETE FROM medicine_info WHERE medicine_code = @code";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
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

        public List<MedicineInfoModel> GetAllMedicineInfo()
        {
            try
            {
                List<MedicineInfoModel> medicineInfos = new List<MedicineInfoModel>();
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM medicine_info";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                MedicineInfoModel medicineInfo = new MedicineInfoModel
                                {
                                    MedicineCode = reader["medicine_code"].ToString(),
                                    MedicineName = reader["medicine_name"].ToString(),
                                    UnitType = Convert.ToInt32(reader["unit_type"]),
                                    MedicinePrice = Convert.ToDecimal(reader["medicine_price"]),
                                    MedicineImage = reader["medicine_img"].ToString(),
                                    MedicineContent = reader["medicine_content"].ToString(),
                                    MedicineElement = reader["medicine_element"].ToString(),
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

        public MedicineInfoModel GetMedicineInfoByMedicineCode(string medicineCode)
        {
            try
            {
                MedicineInfoModel medicineInfo = null;
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM medicine_info WHERE medicine_code = @code";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@code", medicineCode);
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                medicineInfo = new MedicineInfoModel
                                {
                                    MedicineCode = reader["medicine_code"].ToString(),
                                    MedicineName = reader["medicine_name"].ToString(),
                                    UnitType = Convert.ToInt32(reader["unit_type"]),
                                    MedicinePrice = Convert.ToDecimal(reader["medicine_price"]),
                                    MedicineImage = reader["medicine_img"].ToString(),
                                    MedicineContent = reader["medicine_content"].ToString(),
                                    MedicineElement = reader["medicine_element"].ToString(),
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

        public void UpdateMedicineInfo(string medicineCode, MedicineInfoModel medicineInfo)
        {
            try
            {
                using(var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"UPDATE medicine_info
                                     SET medicine_code = @code,
                                         medicine_name = @name,
                                         unit_type = @unit,
                                         medicine_price = @price,
                                         medicine_img = @img,
                                         medicine_content = @content,
                                         medicine_element = @element,
                                         group_code = @groupCode
                                     WHERE medicine_code = @medicineCode";
                    using(var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("code", medicineInfo.MedicineCode);
                        cmd.Parameters.AddWithValue("name", medicineInfo.MedicineName);
                        cmd.Parameters.AddWithValue("unit", medicineInfo.UnitType);
                        cmd.Parameters.AddWithValue("price", medicineInfo.MedicinePrice);
                        cmd.Parameters.AddWithValue("img", medicineInfo.MedicineImage);
                        cmd.Parameters.AddWithValue("content", medicineInfo.MedicineContent);
                        cmd.Parameters.AddWithValue("element", medicineInfo.MedicineElement);
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
