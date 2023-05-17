using CarRentalManager.dao;
using CarRentalManager.models;
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
    /// Interaction logic for CancelForm.xaml
    /// </summary>
    public partial class CancelForm : Window
    {
        CustomerDAO customerDAO = new CustomerDAO();
        CarDAO carDAO= new CarDAO();
        OrderDAO orderDAO= new OrderDAO();
        public CancelForm()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            Order order = orderDAO.getOrderById(myValue.ToString());
            if (order != null)
            {
                txtNameCustomer.Text = customerDAO.getCustomerById(order.CustomerId.ToString()).Name;   
                txtNameCar.Text = carDAO.getCarById(order.CarId.ToString()).Name;
            }
        }
    }
}
