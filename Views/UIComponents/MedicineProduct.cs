using PharmacySystem.Common;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PharmacySystem.Views.UIComponents
{
    public partial class MedicineProduct : UserControl, IMedicineProduct
    {
        private string selectedImagePath;
        private string medicineCode;
        private string unitType;

        public MedicineProduct()
        {
            InitializeComponent();
            btnChoose.Click += (sender, e) =>
            {
                AddToCart?.Invoke(this, EventArgs.Empty);
            };
           
        }

        public string MedicineName
        {
            get => lbName.Text;
            set => lbName.Text = value;
        }
        public int Quantity
        {
            get => int.TryParse(lbQuantity.Text, out int result) ? result : 0;
            set => lbQuantity.Text = value.ToString();
        }

        public string UnitType
        {
            get => unitType;
            set
            {
                // Gán giá trị cho unitType và có thể thực hiện các kiểm tra cần thiết
                unitType = value ?? "N/A"; // Nếu giá trị null, gán giá trị mặc định
            }
        }

        public string MedicineCode
        {
            get => medicineCode;
            set => medicineCode = value;
        }

        public decimal MedicinePrice
        {
            get
            {

                string priceText = lbPrice.Text.Replace("₫", "").Replace(".", "").Trim();
                return decimal.TryParse(priceText, out var price) ? price : 0;
            }
            set
            {
                
                lbPrice.Text = $"{CurrencyFormatter.FormatVND(value)}";
            }
        }



        public string MedicineImage
        {
            get => selectedImagePath;
            set
            {
                selectedImagePath = value;
                LoadMedicineImage(selectedImagePath);
            }
        }

        private void LoadMedicineImage(string imagePath)
        {
            try
            {
                pbMedicineImage.ImageLocation = imagePath;
            }
            catch (Exception ex)
            {
                // Handle image loading failure
                MessageBox.Show($"Image not found or inaccessible\nErr: {ex.Message}.", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pbMedicineImage.Image = Properties.Resources.Panadol_Extra_Advance_Box_32s380x463; // Set a default placeholder image
            }
        }

        

        public event EventHandler AddToCart;

       
    }
}
