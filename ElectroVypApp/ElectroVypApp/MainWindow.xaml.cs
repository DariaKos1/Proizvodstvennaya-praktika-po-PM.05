using System;
using System.Collections.Generic;
using System.Windows;

namespace ElectroVypApp
{
    public partial class MainWindow : Window
    {
        private List<Product> products;
        private Product selectedProduct;
        private List<CalculationHistory> history;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            LoadHistory();
            UpdateStatus("Приложение запущено");
        }

        private void LoadData()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "Диод D143-800", Type = "Полупроводниковый", PowerKw = 0, Price = 5200 },
                new Product { Id = 2, Name = "Тиристор T253-1000", Type = "Полупроводниковый", PowerKw = 0, Price = 6800 },
                new Product { Id = 3, Name = "Преобразователь Омега-3 7.5 кВт", Type = "Преобразователь", PowerKw = 7.5m, Price = 35000 },
                new Product { Id = 4, Name = "Преобразователь Омега-3 22 кВт", Type = "Преобразователь", PowerKw = 22, Price = 58000 },
                new Product { Id = 5, Name = "Выпрямитель В-ТПЕ-1М", Type = "Оборудование", PowerKw = 110, Price = 95000 },
                new Product { Id = 6, Name = "Система охлаждения О-200", Type = "Комплектующие", PowerKw = 0, Price = 8900 },
                new Product { Id = 7, Name = "Блок управления БУ-ПЧ", Type = "Комплектующие", PowerKw = 0, Price = 4500 }
            };
            grid.ItemsSource = products;
        }

        private void LoadHistory()
        {
            history = new List<CalculationHistory>();
        }

        private void UpdateStatus(string message)
        {
            tbStatus.Text = $"{DateTime.Now:HH:mm:ss} - {message}";
        }

        private void grid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedProduct = grid.SelectedItem as Product;
            if (selectedProduct != null)
            {
                UpdateStatus($"Выбран товар: {selectedProduct.Name}");
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (int.TryParse(txtQuantity.Text, out int quantity) && quantity > 0)
            {
                decimal total = selectedProduct.Price * quantity;
                tbResult.Text = $"ИТОГО: {total:N2} руб.";
                UpdateStatus($"Расчет: {selectedProduct.Name} x{quantity} = {total:N2} руб.");

                history.Add(new CalculationHistory
                {
                    ProductName = selectedProduct.Name,
                    Quantity = quantity,
                    TotalPrice = total,
                    Date = DateTime.Now
                });
            }
            else
            {
                MessageBox.Show("Введите корректное количество!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            tbResult.Text = "";
            txtQuantity.Text = "1";
            UpdateStatus("Каталог обновлен");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductsWindow(products);
            window.ShowDialog();
            LoadData();
            UpdateStatus("Список товаров обновлен");
        }

        private void ProductTypes_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductTypesWindow();
            window.ShowDialog();
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            var window = new HistoryWindow(history);
            window.ShowDialog();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            var window = new AboutWindow();
            window.ShowDialog();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal PowerKw { get; set; }
        public decimal Price { get; set; }
    }

    public class CalculationHistory
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
    }
}