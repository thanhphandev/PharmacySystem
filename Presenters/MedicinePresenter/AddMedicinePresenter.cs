using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Services.Interface;
using PharmacySystem.Services.MedicineService;
using PharmacySystem.Views.MedicinesForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PharmacySystem.Presenters.MedicinePresenter
{
    public class AddMedicinePresenter
    {
        private readonly IAddMedicineForm _addMedicineForm;
        private readonly string _connectionString;

        private readonly MedicineService _medicineService;
        private readonly MedicineInfoService _medicineInfoService;

        private readonly SupplierService _supplierService;
        private readonly UnitTypeService _unitTypeService;
        private readonly MedicineGroupService _medicineGroupService;

        private readonly IImageUploadService _cloudinaryService;
        public AddMedicinePresenter(IAddMedicineForm addMedicineForm, string connectionString)
        {
            _connectionString = connectionString;
            _addMedicineForm = addMedicineForm;

            _medicineService = new MedicineService(_connectionString);
            _medicineInfoService = new MedicineInfoService(_connectionString);

            _supplierService = new SupplierService(_connectionString);
            _unitTypeService = new UnitTypeService(_connectionString);
            _medicineGroupService = new MedicineGroupService(_connectionString);

            _cloudinaryService = new CloudinaryImageUploadService();

            _addMedicineForm.AddMedicine += OnAddData;
            _addMedicineForm.LeaveTextBoxName += CheckExistMedicineInfo;

            LoadData();
        }

        private void CheckExistMedicineInfo(object sender, EventArgs e)
        {
            string medicineName = _addMedicineForm.MedicineName.Trim();
            if (string.IsNullOrEmpty(medicineName))
                return;
            var medicineInfo = _medicineInfoService.GetMedicineInfoByMedicineName(medicineName);
            if (medicineInfo != null)
            {
                AutoFillData(medicineInfo);
            }

        }

        private void LoadData()
        {
            var unitTypes = _unitTypeService.GetAllUnitTypes();
            var medicineGroups = _medicineGroupService.GetAllMedicineGroups();
            var suppliers = _supplierService.GetAllSuppliers();
            var medicineNames = _medicineInfoService.GetAllMedicineName();
            _addMedicineForm.SetAutoCompleteNameData(medicineNames);
            _addMedicineForm.LoadUnitTypes(unitTypes);
            _addMedicineForm.LoadMedicineGroups(medicineGroups);
            _addMedicineForm.LoadSuppliers(suppliers);
        }

        private async void OnAddData(object sender, EventArgs e)
        {
            try
            {
                string medicineName = _addMedicineForm.MedicineName.Trim();
                var existingMedicineInfo = _medicineInfoService.GetMedicineInfoByMedicineName(medicineName);

                // If the medicine info already exists, we skip adding it
                if (existingMedicineInfo != null)
                {
                    // Create the Medicine and MedicineQuantity using existing medicine info
                    MedicineBatch medicineBatch = new MedicineBatch
                    {
                        MedicineCode = _addMedicineForm.MedicineCode,
                        ExpireDate = _addMedicineForm.ExpireDate,
                        SupplierID = _addMedicineForm.SupplierId,
                        Quantity = _addMedicineForm.Quantity

                    };

                    if (!IsValidData(medicineBatch, existingMedicineInfo)) return;
                    
                    int medicineId = _medicineService.AddMedicine(medicineBatch);

                    MessageBox.Show("Thuốc đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // If MedicineInfo does not exist, create a new MedicineInfo and then Medicine
                    MedicineInfoModel medicineInfo = new MedicineInfoModel
                    {
                        Code = _addMedicineForm.MedicineCode,
                        Name = _addMedicineForm.MedicineName,
                        Price = _addMedicineForm.MedicinePrice,
                        UnitTypeId = _addMedicineForm.UnitType,
                        GroupCode = _addMedicineForm.GroupCode,
                        Ingredients = _addMedicineForm.MedicineElement,
                        Description = _addMedicineForm.MedicineContent
                    };

                    MedicineBatch medicine = new MedicineBatch
                    {
                        MedicineCode = medicineInfo.Code,
                        ExpireDate = _addMedicineForm.ExpireDate,
                        SupplierID = _addMedicineForm.SupplierId,
                        Quantity = _addMedicineForm.Quantity
                    };

                   
                    if (!IsValidData(medicine, medicineInfo)) return;

                    // Handle image upload if necessary
                    string imageUrl = await UploadImageAsync(_addMedicineForm.MedicineImage);
                    medicineInfo.Image = imageUrl;

                    // Add new MedicineInfo and then Medicine
                    _medicineInfoService.AddMedicineInfo(medicineInfo);
                    int medicineId = _medicineService.AddMedicine(medicine);
                    int quantity = medicine.Quantity;


                    MessageBox.Show("Thuốc đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _addMedicineForm.CloseForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra!\nLỗi: {ex.Message}");
            }
        }


        private async Task<string> UploadImageAsync(string imagePath)
        {
            try
            {
                string imageUrl = await _cloudinaryService.UploadImageAsync(imagePath);
                return imageUrl;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra!\nLỗi: {ex.Message}");
                return string.Empty;
            }
        }

        private bool IsValidData(MedicineBatch medicine, MedicineInfoModel medicineInfo)
        {
           
            if (string.IsNullOrWhiteSpace(medicineInfo.Code) || string.IsNullOrWhiteSpace(medicineInfo.Name))
            {
                MessageBox.Show("Mã thuốc và tên thuốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (medicineInfo.Price <= 0)
            {
                MessageBox.Show("Giá thuốc nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

           
            if (medicineInfo.UnitTypeId <= 0)
            {
                MessageBox.Show("Vui lòng chọn loại đơn vị hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (medicine.ExpireDate <= DateTime.Now)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (medicine.Quantity < 0)
            {
                MessageBox.Show("Số lượng thuốc nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(medicineInfo.GroupCode))
            {
                MessageBox.Show("Mã nhóm thuốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (medicine.SupplierID <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (string.IsNullOrWhiteSpace(medicineInfo.Ingredients) || string.IsNullOrWhiteSpace(medicineInfo.Description))
            {
                MessageBox.Show("Thành phần và hàm lượng thuốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            return true;
        }

        private void AutoFillData(MedicineInfoModel medicineInfo)
        {
            _addMedicineForm.MedicineCode = medicineInfo.Code;
            _addMedicineForm.UnitType = medicineInfo.UnitTypeId;
            _addMedicineForm.MedicinePrice = medicineInfo.Price;
            _addMedicineForm.MedicineImage = medicineInfo.Image;
            _addMedicineForm.MedicineContent = medicineInfo.Description;
            _addMedicineForm.MedicineElement = medicineInfo.Ingredients;
            _addMedicineForm.GroupCode = medicineInfo.GroupCode;

        }

    }
}
