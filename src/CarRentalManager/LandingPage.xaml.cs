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
using CarRentalManager.dao;
using CarRentalManager.models;
using CarRentalManager.ViewModel;
using MaterialDesignThemes.Wpf;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for landingPage.xaml
    /// </summary>
    public partial class LandingPage : Window
    {
        readonly CommonDAO commonDao = new CommonDAO();
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
            supplierRegister.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (cbSeats.Items.Count > 0)
                cbSeats.SelectedIndex = 0;
            if (cbDiaChi.Items.Count > 0)
                cbDiaChi.SelectedIndex = 0;
            if (cbBrand.Items.Count > 0)
                cbBrand.SelectedIndex = 0;
        }

        private void chipCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelForm cancelForm = new CancelForm();
            cancelForm.ShowDialog();
        }

        private void LandingPageLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, string> dictFeedback = commonDao.getListFeedbackOfCustomer();
                List<TextBlock> txtbloNameList = new List<TextBlock>() { txtbloName1, txtbloName2, txtbloName3, txtbloName4 };
                List<TextBlock> txtContentList = new List<TextBlock>() { txtContent1, txtContent2, txtContent3, txtContent4 };
                List<Chip> chipContent = new List<Chip>() { chipContent1, chipContent2, chipContent3, chipContent4 };
                
                
                int i = 0;
                foreach (var val in dictFeedback)
                {
                    if (i < txtbloNameList.Count)
                    {
                        txtbloNameList[i].Text = val.Key;
                        txtContentList[i].Text = val.Value;
                        chipContent[i].Content = val.Key.Trim().Split(' ').LastOrDefault()?.FirstOrDefault() ?? default(char); ;
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
