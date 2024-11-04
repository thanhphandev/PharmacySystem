using PharmacySystem.Services;
using PharmacySystem.Services.MedicineService;
using PharmacySystem.Views.MainForm;
using PharmacySystem.Views.PaymentForm;
using System;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class PaymentPresenter
    {
        private readonly IPaymentView _paymentView;
        private readonly IMainView _mainView;
        private readonly MedicineQuantityService _medicineQuantityService;
        private readonly POSService _posService;

        public PaymentPresenter(IPaymentView paymentView, IMainView mainView, string connectionString)
        {
            _paymentView = paymentView;
            _mainView = mainView;

            _medicineQuantityService = new MedicineQuantityService(connectionString);
            _posService = new POSService(connectionString);

            _paymentView.ConfirmPayment += OnConfirmPayment;
        }

        private void OnConfirmPayment(object sender, EventArgs e)
        {
            var totalAmount = _paymentView.TotalAmount;
            var purchasedItems = _mainView.GetCartItems();
            int employeeId = UserSession.UserId;

            _posService.AddPosBill(totalAmount, employeeId);
            foreach (var item in purchasedItems)
            {
                _medicineQuantityService.UpdateQuantityByNearestExpiry(item.MedicineCode, item.Quantity);
            }
            MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _paymentView.CloseForm();

        }
    }
}
