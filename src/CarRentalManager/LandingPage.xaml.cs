using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CarRentalManager.customcontrols;
using CarRentalManager.models;
using CarRentalManager.ViewModel;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for landingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private void Polygon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Chip_Click(object sender, RoutedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SupplierRegister supplierRegister= new SupplierRegister();
            supplierRegister.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            cbDiaChi.Text = null;
            cbBrand.Text = null;
            cbSeats.Text = "0";
        }
    }
}
