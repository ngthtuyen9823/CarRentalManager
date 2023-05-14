using CarRentalManager.state;
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
    /// Interaction logic for SupplierDashBoard.xaml
    /// </summary>
    public partial class SupplierDashBoard : Window
    {
        public SupplierDashBoard()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var landingPage = new LandingPage();
            landingPage.Show();
            Close();
        }
        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1380;
                    this.Height = 800;
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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (!LoginInInforState.isLogin)
            {
                MessageBox.Show("Please login");
                LandingPage landingPage = new LandingPage();
                landingPage.Show();

                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                Close();
            }
            else
            {
                txtUserName.Text = "Hi, " + LoginInInforState.Name;
            }
        }
    }
}
