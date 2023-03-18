using CarRentalManager.dao;
using CarRentalManager.modals;
using CarRentalManager.services;
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
        readonly CarDataService carDataService = new CarDataService();
        readonly CarDAO carDAO = new CarDAO();
        readonly OrderDAO orderDAO = new OrderDAO();
        private int priceCar;
        public RegisterForm()
        {
            InitializeComponent();
        }
        public RegisterForm(string id)
        {           
            InitializeComponent();
            Car currentCar = this.getCarInformation(id);
            this.loadViewModel(currentCar);
        }

        private void loadViewModel(Car car)
        {
            priceCar = car.Price;
            lblIDCar.Content = "ID XE : " + car.ID;
            describeIMG.Source = new BitmapImage(new Uri(car.ImagePath, UriKind.Relative));
            lblNameCar.Content = "Name : "+ car.Name;
            lblBranchCar.Content = "Brand : " + car.Brand;
            lblPublishYear.Content = "Publish Year : " + car.PublishYear;
            lblColorCar.Content = "Color : " + car.Color;
            lblPriceCar.Content = "Price : " + car.Price;
            lblSeats.Content = "Seats : " + car.Seats;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!dpBatdau.SelectedDate.HasValue || !dpKetThuc.SelectedDate.HasValue)
            {
                lblTotalFee.Content = "Select dates";
                return;
            }
            DateTime start = dpBatdau.SelectedDate.Value.Date;
            DateTime end = dpKetThuc.SelectedDate.Value.Date;
            TimeSpan timeSpan = end.Subtract(start);
            lblTotalFee.Content = (timeSpan.TotalDays * priceCar).ToString() + "000 VNĐ" ;
        }
    }
}
