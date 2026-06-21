using System.Collections.Generic;
using System.Windows;

namespace ElectroVypApp
{
    public partial class ProductsWindow : Window
    {
        private List<Product> products;

        public ProductsWindow(List<Product> productsList)
        {
            InitializeComponent();
            products = productsList;
            grid.ItemsSource = products;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductEditWindow();
            if (window.ShowDialog() == true)
            {
                int newId = products.Count + 1;
                products.Add(new Product
                {
                    Id = newId,
                    Name = window.ProductName,
                    Type = window.ProductType,
                    PowerKw = window.PowerKw,
                    Price = window.Price
                });
                grid.ItemsSource = null;
                grid.ItemsSource = products;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selected = grid.SelectedItem as Product;
            if (selected == null)
            {
                MessageBox.Show("Выберите товар!");
                return;
            }

            var window = new ProductEditWindow(selected);
            if (window.ShowDialog() == true)
            {
                selected.Name = window.ProductName;
                selected.Type = window.ProductType;
                selected.PowerKw = window.PowerKw;
                selected.Price = window.Price;
                grid.ItemsSource = null;
                grid.ItemsSource = products;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selected = grid.SelectedItem as Product;
            if (selected == null)
            {
                MessageBox.Show("Выберите товар!");
                return;
            }

            if (MessageBox.Show($"Удалить товар '{selected.Name}'?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                products.Remove(selected);
                grid.ItemsSource = null;
                grid.ItemsSource = products;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}