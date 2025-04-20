using PharmacySystem.Models;
using PharmacySystem.Repositories.SupplierRepository;
using System;
using System.Collections.Generic;
using System.Linq;

public class SupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    public SupplierService(string connectionString)
    {
        _supplierRepository = new SupplierRepository(connectionString);
    }

    public (bool Success, string ErrorMessage) AddSupplier(SupplierModel supplier)
    {
        var validation = ValidateSupplier(supplier);
        if (!validation.Success) return validation;

        supplier.Phone = NormalizePhone(supplier.Phone);

        var exists = _supplierRepository.GetAllSuppliers()
            .Any(s => s.Phone == supplier.Phone);
        if (exists)
            return (false, "Số điện thoại đã tồn tại");

        try
        {
            _supplierRepository.AddSupplier(supplier);
            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            return (false, "Lỗi hệ thống: " + ex.Message);
        }
    }

    public (bool Success, string ErrorMessage) UpdateSupplier(int id, SupplierModel supplier)
    {
        var validation = ValidateSupplier(supplier);
        if (!validation.Success) return validation;

        supplier.Phone = NormalizePhone(supplier.Phone);

        try
        {
            _supplierRepository.UpdateSupplier(id, supplier);
            return (true, string.Empty);
        }
        catch (Exception ex)
        {
            return (false, "Lỗi hệ thống: " + ex.Message);
        }
    }

    private (bool Success, string ErrorMessage) ValidateSupplier(SupplierModel supplier)
    {
        if (string.IsNullOrWhiteSpace(supplier.Name) || string.IsNullOrWhiteSpace(supplier.Phone))
            return (false, "Tên và số điện thoại không được để trống");

        string cleanedPhone = new string(supplier.Phone.Where(char.IsDigit).ToArray());
        if (cleanedPhone.Length < 10 || cleanedPhone.Length > 15)
            return (false, "Số điện thoại không hợp lệ");

        return (true, string.Empty);
    }

    private string NormalizePhone(string phone) =>
        new string(phone.Where(char.IsDigit).ToArray());

    public bool DeleteSupplier(int id)
    {
        try
        {
            _supplierRepository.DeleteSupplier(id);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public List<SupplierModel> GetAllSuppliers()
    {
        return _supplierRepository.GetAllSuppliers();
    }
}
