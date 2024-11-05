using PharmacySystem.Common;
using System;
using System.Windows.Forms;

namespace PharmacySystem.Views.PaymentForm
{
    public partial class PaymentView : Form, IPaymentView
    {
        private decimal totalAmount;

        public event EventHandler ConfirmPayment;

        public PaymentView(decimal totalAmount)
        {
            InitializeComponent();
            TotalAmount = totalAmount;
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            txtTotal.Text = CurrencyFormatter.FormatVND(TotalAmount);

            btnConfirmPayment.Click += delegate
            {
                if (CashReceived < TotalAmount)
                {
                    MessageBox.Show("Số tiền không đủ để thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var result = MessageBox.Show("Thông tin hợp lệ, hệ thống sẽ tiến hành ghi nhận và xuất hóa đơn!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    ConfirmPayment?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        public decimal CashReceived
        {
            get => decimal.TryParse(txtPaidAmount.Text, out var amount) ? amount : 0;
            set => txtPaidAmount.Text = CurrencyFormatter.FormatVND(value);
        }

        public decimal TotalAmount
        {
            get => totalAmount;
            set => totalAmount = value;
        }

        public decimal Change => CashReceived - TotalAmount;

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            txtChange.Text = Change >= 0 ? CurrencyFormatter.FormatVND(Change) : "Insufficient amount";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CloseForm()
        {
            this.Close();
        }
    }
}
