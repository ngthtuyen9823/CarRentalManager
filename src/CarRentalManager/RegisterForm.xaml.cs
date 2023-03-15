using CarRentalManager.dao;
using CarRentalManager.modals;
using CarRentalManager.services;
using System;
using System.Windows;
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
            lblIDXe.Content = "ID XE : " + car.ID;
            describeIMG.Source = new BitmapImage(new Uri(car.ImagePath, UriKind.Relative));
        }

        public string ID { get; set; }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            lblIDXe.Content = ID;
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
    }
}
