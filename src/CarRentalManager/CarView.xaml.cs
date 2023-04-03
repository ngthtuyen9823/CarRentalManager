using CarRentalManager.modals;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for CarView.xaml
    /// </summary>
    public partial class CarView : UserControl
    {

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public CarView()
        {
            InitializeComponent();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                var selectedCar = lsvCar.SelectedItems[0] as Car;
                if (selectedCar == null)
                {
                    return;
                }
                var carForm = new CarForm(item, selectedCar);
                carForm.Show();

            }
        }
    }
}
