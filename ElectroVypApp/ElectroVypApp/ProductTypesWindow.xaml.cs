using System.Collections.Generic;
using System.Windows;

namespace ElectroVypApp
{
    public partial class ProductTypesWindow : Window
    {
        public ProductTypesWindow()
        {
            InitializeComponent();

            var types = new List<ProductType>
            {
                new ProductType { Code = "SPP", Name = "Силовые полупроводниковые приборы", BaseRate = 4500 },
                new ProductType { Code = "PC", Name = "Преобразователи частоты", BaseRate = 35000 },
                new ProductType { Code = "PE", Name = "Преобразовательное оборудование", BaseRate = 75000 },
                new ProductType { Code = "ACC", Name = "Комплектующие", BaseRate = 1200 }
            };

            grid.ItemsSource = types;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    public class ProductType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal BaseRate { get; set; }
    }
}