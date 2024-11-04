using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.PaymentForm
{
    public interface IPaymentView
    {
        decimal PaidAmount { get; set; }
        decimal TotalAmount { get; set; }
        decimal Change { get; }
        void CloseForm();
        event EventHandler ConfirmPayment;
    }
}
