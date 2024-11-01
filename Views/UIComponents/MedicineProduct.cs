using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PharmacySystem.Views.UIComponents
{
    public partial class MedicineProduct : UserControl, IMedicineProduct
    {
        private string selectedImagePath;
        private string medicineCode;
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

        public decimal MedicinePrice
        {
            get => decimal.TryParse(lbPrice.Text, out var price) ? price : 0;
            set => lbPrice.Text = value.ToString("F2");
        }

        public string MedicineCode
        {
            get => medicineCode;
            set => medicineCode = value;
        }

        public string MedicineImage
        {
            get => selectedImagePath;
            set
            {
                selectedImagePath = value;
                try
                {
                    pbMedicineImage.ImageLocation = selectedImagePath;
                }
                catch (Exception ex)
                {
                    // Handle image loading failure (optional logging or user feedback)
                    MessageBox.Show($"Image not found or inaccessible\n Err{ex.Message}.", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pbMedicineImage.Image = null; // or set a default placeholder image
                }
            }
        }

        public event EventHandler AddToCart;
    }
}
