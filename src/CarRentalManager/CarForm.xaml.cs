using CarRentalManager.modals;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for CarForm.xaml
    /// </summary>
    public partial class CarForm : Window
    {
        public CarForm(ListViewItem selectedItem, Car selectedCar)
        {
            InitializeComponent();
            DataContext = selectedItem;
            LoadViewModel(selectedCar);
        }
        private void LoadViewModel(Car selectedCar)
        {
            if (DataContext != null)
            {
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
        private bool IsMaximize = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
