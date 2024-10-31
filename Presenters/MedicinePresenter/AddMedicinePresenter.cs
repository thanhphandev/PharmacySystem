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

namespace PharmacySystem.Presenters.MedicinePresenter
{
    public class AddMedicinePresenter
    {
        private readonly IAddMedicineForm _addMedicineForm;
        private readonly string _connectionString;

        private readonly MedicineService _medicineService;
        private readonly MedicineInfoService _medicineInfoService;
        private readonly MedicineQuantityService _medicineQuantityService;

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
            _medicineQuantityService = new MedicineQuantityService(_connectionString);

            _supplierService = new SupplierService(_connectionString);
            _unitTypeService = new UnitTypeService(_connectionString);
            _medicineGroupService = new MedicineGroupService(_connectionString);

            _cloudinaryService = new CloudinaryImageUploadService();

            _addMedicineForm.AddMedicine += OnAddData;
        }

        public void LoadData()
        {
            var unitTypes = _unitTypeService.GetAllUnitTypes();
            var medicineGroups = _medicineGroupService.GetAllMedicineGroups();
            var suppliers = _supplierService.GetAllSuppliers();
            _addMedicineForm.LoadUnitTypes(unitTypes);
            _addMedicineForm.LoadMedicineGroups(medicineGroups);
            _addMedicineForm.LoadSuppliers(suppliers);
        }

        private async void OnAddData(object sender, EventArgs e)
        {
            try
            {
                // Init Object
                string imageUrl = await UploadImageAsync(_addMedicineForm.MedicineImage);

                MedicineInfoModel medicineInfo = new MedicineInfoModel
                {
                    MedicineCode = _addMedicineForm.MedicineCode,
                    MedicineName = _addMedicineForm.MedicineName,
                    MedicinePrice = _addMedicineForm.MedicinePrice,
                    MedicineImage = imageUrl,
                    UnitType = _addMedicineForm.UnitType,
                    GroupCode = _addMedicineForm.GroupCode,
                    MedicineElement = _addMedicineForm.MedicineElement,
                    MedicineContent = _addMedicineForm.MedicineContent
                };


                MedicineModel medicine = new MedicineModel
                {
                    MedicineCode = medicineInfo.MedicineCode,
                    ExpireDate = _addMedicineForm.ExpireDate,
                    SupplierId = _addMedicineForm.SupplierId
                };

                MedicineQuantityModel medicineQuantity = new MedicineQuantityModel
                {
                    Quantity = _addMedicineForm.Quantity
                };

                if (!IsValidData(medicine, medicineInfo, medicineQuantity)) return;

                _medicineInfoService.AddMedicineInfo(medicineInfo);
                int medicineId = _medicineService.AddMedicine(medicine);
                int quantity = medicineQuantity.Quantity;
                
                _medicineQuantityService.AddMedicineQuantity(medicineId, quantity);

                MessageBox.Show("Thuốc đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _addMedicineForm.CloseForm();

            } catch(Exception ex)
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

        private bool IsValidData(MedicineModel medicine, MedicineInfoModel medicineInfo, MedicineQuantityModel medicineQuantity)
        {
           
            if (string.IsNullOrWhiteSpace(medicineInfo.MedicineCode) || string.IsNullOrWhiteSpace(medicineInfo.MedicineName))
            {
                MessageBox.Show("Mã thuốc và tên thuốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            if (medicineInfo.MedicinePrice <= 0)
            {
                MessageBox.Show("Giá thuốc nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

           
            if (medicineInfo.UnitType <= 0)
            {
                MessageBox.Show("Vui lòng chọn loại đơn vị hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (medicine.ExpireDate <= DateTime.Now)
            {
                MessageBox.Show("Hạn sử dụng phải lớn hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (medicineQuantity.Quantity < 0)
            {
                MessageBox.Show("Số lượng thuốc nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(medicineInfo.GroupCode))
            {
                MessageBox.Show("Mã nhóm thuốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (medicine.SupplierId <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (string.IsNullOrWhiteSpace(medicineInfo.MedicineElement) || string.IsNullOrWhiteSpace(medicineInfo.MedicineContent))
            {
                MessageBox.Show("Thành phần và hàm lượng thuốc không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            
            return true;
        }

    }
}
