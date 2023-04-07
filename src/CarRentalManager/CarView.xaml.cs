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
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                string selectedFileName = dlg.FileName;
                ImagePath.Text = selectedFileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
            }
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
                ID.Text = selectedCar.ID.ToString();
                SupplierId.Text = selectedCar.SupplierId.ToString();
                Name.Text = selectedCar.Name;
                Brand.Text = selectedCar.Brand;
                Color.Text = selectedCar.Color;
                PublishYear.Text = selectedCar.PublishYear.ToString();
                Type.Text = selectedCar.Type.ToString();
                Status.Text = selectedCar.Status.ToString();
                DrivingType.Text = selectedCar.DrivingType.ToString();
                Seats.Text = selectedCar.Seats.ToString();
                LicensePlate.Text = selectedCar.LicensePlate;
                Price.Text = selectedCar.Price.ToString();
                ImagePath.Text = selectedCar.ImagePath;
            }
        }
    }
}
