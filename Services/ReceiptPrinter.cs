using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacySystem.Models;

namespace PharmacySystem.Services
{
    public class ReceiptPrinter
    {
        
        private readonly string _pharmacyName = "Nhà Thuốc Pharmacy SYS";
        private readonly string _address = "Mỹ Xuyên, Long Xuyên, An Giang";
        private readonly string _phone = "(03) 5763 1034";
        private readonly string _taxCode = "5637289200";

        private readonly DateTime _invoiceDate = DateTime.Now;
        private readonly string _employeeName;
        private readonly int _employeeCode;

        private readonly decimal _totalAmount;
        private readonly decimal taxRate = 0.1m; // 10%
        private readonly decimal _cashReceived;

        private readonly List<MedicineProductModel> _products;

        public ReceiptPrinter(string employeeName, int employeeCode, List<MedicineProductModel> product, decimal totalAmount, decimal cashReceived)
        {
            _employeeName = employeeName;
            _employeeCode = employeeCode;
            _products = product;
            _totalAmount = totalAmount;
            _cashReceived = cashReceived;
        }

        public void Print()
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintReceipt;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog { Document = printDoc };
            if (previewDialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int y = 20;
            Font font = new Font("Arial", 10);
            Font boldFont = new Font("Arial", 10, FontStyle.Bold);
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };

            // Thông tin nhà thuốc
            PrintCenteredText(g, _pharmacyName, boldFont, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, "Địa chỉ: " + _address, font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, "Điện thoại: " + _phone, font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, "Mã số thuế: " + _taxCode, font, ref y, e.PageBounds.Width, 30);

            // Tiêu đề hóa đơn
            PrintCenteredText(g, "HÓA ĐƠN BÁN HÀNG", new Font("Arial", 12, FontStyle.Bold), ref y, e.PageBounds.Width, 30);
            PrintCenteredText(g, "Ngày: " + _invoiceDate.ToString("dd/MM/yyyy - HH:mm"), font, ref y, e.PageBounds.Width, 30);

            // Thông tin nhân viên
            PrintCenteredText(g, $"Nhân viên: {_employeeName} (Mã NV: {_employeeCode})", font, ref y, e.PageBounds.Width, 30);

            // Bảng chi tiết sản phẩm
            PrintCenteredText(g, "STT  Tên thuốc            Số lượng     Đơn giá      Thành tiền", font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, new string('-', 60), font, ref y, e.PageBounds.Width, 20);

            // Chi tiết sản phẩm
            int index = 1;
            foreach (var item in _products)
            {
                decimal lineTotal = item.Quantity * item.Price;
                string itemLine = FormatItemLine(index++, item);
                PrintCenteredText(g, itemLine, font, ref y, e.PageBounds.Width, 20);
            }


            // Tính toán tổng
            decimal subTotal = _totalAmount;
            decimal taxAmount = subTotal * taxRate;
            decimal grandTotal = subTotal + taxAmount;
            decimal change = _cashReceived - grandTotal;

            y += 20;
            PrintCenteredText(g, "------------------------------------------------------------", font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, $"Tổng tiền hàng: {subTotal:0,0} VNĐ", font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, $"Thuế GTGT (10%): {taxAmount:0,0} VNĐ", font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, $"Tổng thanh toán: {grandTotal:0,0} VNĐ", boldFont, ref y, e.PageBounds.Width, 30);
            PrintCenteredText(g, $"Tiền khách đưa: {_cashReceived:0,0} VNĐ", font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, $"Tiền thừa trả lại: {change:0,0} VNĐ", font, ref y, e.PageBounds.Width, 30);

            // Lời cảm ơn và chính sách
            PrintCenteredText(g, "Cảm ơn quý khách đã mua hàng tại " + _pharmacyName + "!", font, ref y, e.PageBounds.Width, 20);
            PrintCenteredText(g, "Chính sách đổi trả: Đổi trả trong 7 ngày nếu còn nguyên vẹn.", font, ref y, e.PageBounds.Width, 20);
        }

        private string FormatItemLine(int index, MedicineProductModel item)
        {
            return $"{index,-4} {item.MedicineName,-20} {item.Quantity,-5} {item.Price,10:0,0} {item.Quantity * item.Price,12:0,0}";
        }

        private void PrintCenteredText(Graphics g, string text, Font font, ref int y, int pageWidth, int height)
        {
            StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString(text, font, Brushes.Black, new RectangleF(0, y, pageWidth, height), centerFormat);
            y += height;
        }
    }
}
