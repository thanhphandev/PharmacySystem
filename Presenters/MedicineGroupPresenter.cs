using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineGroupRepository;
using PharmacySystem.Views.MedicineCategoryForm;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

public class MedicineGroupPresenter
{
    private readonly IMedicineGroupAddForm _medicineGroupAddForm;
    private readonly string _connectionString;
    private readonly MedicineGroupRepository _medicineGroupRepository;


    public MedicineGroupPresenter(IMedicineGroupAddForm medicineGroupAddForm, string connectionString)
    {
        _medicineGroupAddForm = medicineGroupAddForm;
        _connectionString = connectionString;
        _medicineGroupRepository = new MedicineGroupRepository(connectionString);

        
        _medicineGroupAddForm.AddMedicineGroup += OnAddMedicineGroup;
    }


    private void OnAddMedicineGroup(object sender, EventArgs e)
    {
        MedicineGroupModel medicineGroup = new MedicineGroupModel();

        // Perform validation
        if (string.IsNullOrWhiteSpace(_medicineGroupAddForm.GroupCode))
        {
            MessageBox.Show("Mã nhóm thuốc không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(_medicineGroupAddForm.GroupName))
        {
            MessageBox.Show("Tên nhóm thuốc không được để trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }


        try
        {
            medicineGroup.GroupCode = _medicineGroupAddForm.GroupCode.Trim();
            medicineGroup.GroupName = _medicineGroupAddForm.GroupName.Trim();
            medicineGroup.Description = _medicineGroupAddForm.Content.Trim();

            _medicineGroupRepository.AddMedicineGroup(medicineGroup);

            ClearData();
            MessageBox.Show("Nhóm thuốc đã được thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _medicineGroupAddForm.CloseForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Đã có lỗi xảy ra! Vui lòng thử lại\nLỗi: {ex.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearData()
    {
        _medicineGroupAddForm.GroupCode = string.Empty;
        _medicineGroupAddForm.GroupName = string.Empty;
        _medicineGroupAddForm.Content = string.Empty;
    }
}
