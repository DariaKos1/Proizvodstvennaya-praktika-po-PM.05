using System.Collections.Generic;
using System.Windows;

namespace ElectroVypApp
{
    public partial class HistoryWindow : Window
    {
        public HistoryWindow(List<CalculationHistory> history)
        {
            InitializeComponent();
            grid.ItemsSource = history;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}