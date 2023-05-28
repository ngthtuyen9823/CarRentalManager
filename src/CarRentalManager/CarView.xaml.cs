using CarRentalManager.models;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MaterialDesignColors;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices.ComTypes;

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
            FilterBy.ItemsSource = new string[] { "ID", "SupplierId", "Name", "Brand" };
        }
        private bool IDFilter(object obj)
        {
            var Filterobj = obj as Car;
            string filterobj = Filterobj.ID.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool SupplierIdFilter(object obj)
        {
            var Filterobj = obj as Car;
            string filterobj = Filterobj.SupplierId.ToString().ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool NameFilter(object obj)
        {
            var Filterobj = obj as Car;
            string filterobj = Filterobj.Name.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        private bool BrandFilter(object obj)
        {
            var Filterobj = obj as Car;
            string filterobj = Filterobj.Brand.ToLower();
            return filterobj.Contains(FilterTextBox.Text.ToLower());
        }
        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case nameof(ID):
                    return IDFilter;
                case nameof(SupplierId):
                    return SupplierIdFilter;
                case nameof(Name):
                    return NameFilter;
                case nameof(Brand):
                    return BrandFilter;
            }
            return NameFilter;
        }
        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                lsvCar.Items.Filter = null;
            }
            else
            {
                lsvCar.Items.Filter = GetFilter();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            lsvCar.Items.Filter = GetFilter();
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            Nullable<bool> result = dlg.ShowDialog();
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
                PublishYear.Text = selectedCar?.PublishYear?.ToString() ?? "";
                Type.Text = selectedCar.Type.ToString().Trim();
                Status.Text = selectedCar.Status.ToString().Trim();
                DrivingType.Text = selectedCar.DrivingType.ToString().Trim();
                Seats.Text = selectedCar.Seats.ToString();
                LicensePlate.Text = selectedCar.LicensePlate;
                Price.Text = selectedCar.Price.ToString();
                ImagePath.Text = selectedCar.ImagePath;
            }
        }
    }
}
