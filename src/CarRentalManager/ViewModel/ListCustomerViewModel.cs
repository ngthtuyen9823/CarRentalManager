using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CarRentalManager.enums;
using static System.Net.Mime.MediaTypeNames;
using CarRentalManager.services;
using System.Diagnostics;
using System.Security.Policy;
using System.Globalization;
using CarRentalManager.dao;

namespace CarRentalManager.ViewModel
{
    public class ListCustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> list;
        public ObservableCollection<Customer> List { get; set; }
        readonly CustomerDAO customerDAO = new CustomerDAO();

        public ListCustomerViewModel() 
        {
            List = getListObservableCustomer();
        }
        public ObservableCollection<Customer> getListObservableCustomer()
        {
            List<Customer> customers = customerDAO.getListCustomer();
            ObservableCollection<Customer> customerList = new ObservableCollection<Customer>(customers);
            return customerList;
        }
    }
}
