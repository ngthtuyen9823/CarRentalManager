﻿using CarRentalManager.dao;
using CarRentalManager.modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.ObjectModel;

namespace CarRentalManager.ViewModel
{
    public class RegistrationVM : BaseViewModel, IDataErrorInfo
    {
        public ObservableCollection<Order> List { get; set; }
        public string Error { get { return null; } }
        private string _username;
        public ICommand RegisterCommand { get; set; }
        readonly OrderDAO orderDAO= new OrderDAO();
        readonly CommonDAO commonDAO = new CommonDAO();
        readonly CustomerDAO customerDAO = new CustomerDAO();
        readonly VariableService variableService = new VariableService();
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public RegistrationVM() 
        {
            List = getListObservableOrder();
            RegisterCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                int lastOrderId = commonDAO.getLastId(ETableName.ORDER);
                int lastCustomerId = commonDAO.getLastId(ETableName.CUSTOMER);

                customerDAO.createNewCustomer(lastCustomerId + 1, PhoneNumber, Name, Email != null ? Email : "", IdCard != null ? IdCard : "", BookingPlace);

                orderDAO.addOrderToList(lastOrderId + 1, variableService.parseStringToInt(CarId), lastCustomerId + 1, BookingPlace, StartDate, EndDate, TotalFee);

            });
        }

        public void handleRegister()
        {
            //1 Add customer


        }

        private int totalFee;

        public int TotalFee
        {
            get { return totalFee; }
            set
            {
                if (value != totalFee)
                {
                    totalFee = value;
                    OnPropertyChanged("TotalFee");
                }
            }
        }
        private string bookingPlace;
        public string BookingPlace
        {
            get { return bookingPlace; }
            set
            {
                if (value != bookingPlace)
                {
                    bookingPlace = value;
                    OnPropertyChanged("BookingPlace");
                }
            }
        }
        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value != startDate)
                {
                    startDate = value;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value != endDate)
                {
                    endDate = value;
                    OnPropertyChanged("EndDate");
                }
            }
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
        private string phoneNumber;

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value != phoneNumber)
                {
                    phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        private string carId;

        public string CarId
        {
            get { return carId; }
            set
            {
                if (value != carId)
                {
                    carId = value;
                    OnPropertyChanged("CarId");
                }
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged("Email");
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

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Username":
                        if (string.IsNullOrWhiteSpace(Username))
                            result = "Username cannot be empty";
                        else if (Username.Length < 5)
                            result = "Username must be a minimum of 5 characters.";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                OnPropertyChanged(ref _username, value);
            }
        }
        public ObservableCollection<Order> getListObservableOrder()
        {
            List<Order> Orders = orderDAO.getListOrder();
            ObservableCollection<Order> OrderList = new ObservableCollection<Order>(Orders);
            return OrderList;
        }
    }
}