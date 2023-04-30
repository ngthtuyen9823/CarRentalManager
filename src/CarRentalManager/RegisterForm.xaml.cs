using CarRentalManager.dao;
using CarRentalManager.enums;
using CarRentalManager.models;
using CarRentalManager.services;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        readonly SqlQueryService sqlService = new SqlQueryService();
        readonly CarDAO carDAO = new CarDAO();
        readonly OrderDAO orderDAO = new OrderDAO();
        readonly VariableService variableService = new VariableService();

        private int priceCar;
        public RegisterForm()
        {
            InitializeComponent();
        }
        public RegisterForm(string id)
        {           
            InitializeComponent();
            dpBatdau.SelectedDate = DateTime.Today;
            dpKetThuc.SelectedDate= DateTime.Today;
            Car currentCar = this.getCarInformation(id);
            this.loadViewModel(currentCar);
        }

        private void loadViewModel(Car car)
        {
            bool isExistImage = System.IO.File.Exists(car.ImagePath);
            priceCar = car.Price;
            lblIDCar.Content = "ID Car : " + car.ID;
            describeIMG.Source = car.ImagePath.ToLower().IndexOf("asset") == 1 
                ? new BitmapImage(new Uri(car.ImagePath, UriKind.Relative)) 
                : isExistImage ? new BitmapImage(new Uri(car.ImagePath)) : new BitmapImage();
            lblNameCar.Content = "Name : "+ car.Name;
            lblBranchCar.Content = "Brand : " + car.Brand;
            lblPublishYear.Content = "Publish Year : " + car.PublishYear;
            lblColorCar.Content = "Color : " + car.Color;
            lblPriceCar.Content = "Price : " + car.Price;
            lblSeats.Content = "Seats : " + car.Seats;

            ((dynamic)this.DataContext).CarId = car.ID;
        }

        public string ID { get; set; }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            lblIDCar.Content = ID;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private Car getCarInformation(string id)
        {
            return carDAO.getCarById(id);
        }


        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    txtTen.Clear();
        //    txtSdt.Clear();
        //    txtDiachi.Clear();
        //}

        private void btnTinhtien_Click(object sender, RoutedEventArgs e)
        {
            if (!dpBatdau.SelectedDate.HasValue || !dpKetThuc.SelectedDate.HasValue)
            {
                lblTotalFee.Content = "Select dates";
                return;
            }
            DateTime start = dpBatdau.SelectedDate.Value.Date;
            DateTime end = dpKetThuc.SelectedDate.Value.Date;
            TimeSpan timeSpan = end.Subtract(start);
            string totalFee = ((timeSpan.TotalDays * priceCar) - getDiscout(timeSpan.TotalDays * priceCar)).ToString();
            lblTotalFee.Content = totalFee + "000 VNĐ";
            yourDiscout.Text = "Đã áp dụng mã giảm " + getDiscout(timeSpan.TotalDays * priceCar).ToString() + ".000VND";
            ((dynamic)this.DataContext).TotalFee = variableService.parseStringToInt(totalFee);
        }

        BitmapImage bitmap = new BitmapImage();

        private void btnCMNDFront_Click(object sender, RoutedEventArgs e)
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
                txtTruocCmnd.Text = selectedFileName;
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
            }
        }

        private void btnCMNDBack_Click(object sender, RoutedEventArgs e)
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
                txtSauCmnd.Text = selectedFileName;
                bitmap.UriSource = new Uri(selectedFileName);
            }
        }

        private void btnTiencoc_Click(object sender, RoutedEventArgs e)
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
                txtMinhchung.Text = selectedFileName;
                bitmap.UriSource = new Uri(selectedFileName);
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            lblTotalFee.Content = string.Empty;
        }

        private double getDiscout(double price)
        {

            if (price >= 1000 && price < 2000)
            {
                return ((double)EDiscout.VOUCHER1M);
            }
            else if (price >= 2000 && price < 3000)
            {
                return ((double)EDiscout.VOUCHER2M);
            }
            else if (price >= 3000)
            {
                return ((double)EDiscout.VOUCHERMORE3M);
            }
            else
                return 0;
        }
    }
}
