using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using CarRentalManager.dao;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

namespace CarRentalManager.ViewModel
{
    public class ListCustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> list;
        public ObservableCollection<Customer> List { get; set; }
        public ICommand AddCommand { get; set; }
        readonly CustomerDAO customerDAO = new CustomerDAO();
        public ListCustomerViewModel() 
        {
            List = getListObservableCustomer();
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                customerDAO.addCustomerToList(ID, Name, PhoneNumber, Email, IdCard, Address, CreatedAt, UpdatedAt);
                List = getListObservableCustomer();
                OnPropertyChanged(nameof(List));
            });
        }
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private int id;

        public int ID
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return name; }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        private string email;
            
        public string Email
        {
            get { return email; }
            set
            {
                if (value != Email)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                if (value != Address)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        private string idCard;

        public string IdCard
        {
            get { return idCard; }
            set
            {
                if (value != idCard)
                {
                    idCard = value;
                    OnPropertyChanged("IdCard");
                }
            }
        }
        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set
            {
                if (value != createdAt)
                {
                    createdAt = value;
                    OnPropertyChanged("CreatedAt");

                }
            }
        }
        private DateTime updatedAt;

        public DateTime UpdatedAt
        {
            get { return updatedAt; }
            set
            {
                if (value != updatedAt)
                {
                    updatedAt = value;
                    OnPropertyChanged("UpdatedAt");

                }
            }
        }

        public ObservableCollection<Customer> getListObservableCustomer()
        {
            List<Customer> customers = customerDAO.getListCustomer();
            ObservableCollection<Customer> customerList = new ObservableCollection<Customer>(customers);
            return customerList;
        }

    }
}
