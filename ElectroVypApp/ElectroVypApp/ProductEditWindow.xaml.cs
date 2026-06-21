using System.Windows;

namespace ElectroVypApp
{
    public partial class ProductEditWindow : Window
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal PowerKw { get; set; }
        public decimal Price { get; set; }
        public bool IsSaved { get; private set; }

        public ProductEditWindow(Product product = null)
        {
            InitializeComponent();

            if (product != null)
            {
                txtName.Text = product.Name;
                cmbType.Text = product.Type;
                txtPower.Text = product.PowerKw.ToString();
                txtPrice.Text = product.Price.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите наименование!");
                return;
            }

            decimal power = 0;
            if (!string.IsNullOrWhiteSpace(txtPower.Text))
            {
                decimal.TryParse(txtPower.Text, out power);
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену!");
                return;
            }

            ProductName = txtName.Text;
            ProductType = cmbType.Text;
            PowerKw = power;
            Price = price;
            IsSaved = true;

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}