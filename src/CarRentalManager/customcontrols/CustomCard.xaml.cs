using CarRentalManager.dao;
using CarRentalManager.enums;
using CarRentalManager.models;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace CarRentalManager
{
    /// <summary>
    /// Interaction logic for CustomCard.xaml
    /// </summary>
    public partial class CustomCard : UserControl
    {

        readonly OrderDAO orderDAO = new OrderDAO();
        public CustomCard()
        {
            InitializeComponent();            
        }
        private void btnLoadRegister_Click(object sender, RoutedEventArgs e)
        {
            var myValue = ((Button)sender).Tag;
            RegisterForm loadRegister = new RegisterForm(myValue.ToString());            
            loadRegister.ShowDialog();
        }        
        private double getRating(double total)
        {
            double allTotal = orderDAO.getListOrder().Count();
            return 3.5+(total/allTotal)*5; // default rate of cars have any order = 3.5
        }       

        private void rbStar_Loaded(object sender, RoutedEventArgs e)
        {
            var myValue = rbStar.Tag;
            List<Order> orders = orderDAO.getListOrderByCondition(string.Format("carId = {0}", myValue.ToString()));
            if (orders != null)
                rbStar.Value = getRating(orders.Count());
            else
                rbStar.Value = 0;
        }
    }
}
