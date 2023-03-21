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
using CarRentalManager.enums;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using System.Xml.Linq;

namespace CarRentalManager.ViewModel
{
    public class ListOrderViewModel : BaseViewModel, IDataErrorInfo
    {
        public ObservableCollection<Order> List { get; set; }
        public ICommand AddCommand { get; set; }

        readonly OrderDAO orderDao = new OrderDAO();
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public ListOrderViewModel()
        {
            List = getListObservableOrder();
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (ErrorCollection.Count > 0)
                    return false;
                else
                    return true;
            }, (p) =>
            {
                orderDao.addOrderToList(ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee);
                List = getListObservableOrder();
                OnPropertyChanged(nameof(List));
                reSetForm();

            });
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
                    OnPropertyChanged("Id");
                }
            }
        }
        private int carId;

        public int CarId
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
        private int customerId;

        public int CustomerId
        {
            get { return customerId; }
            set
            {
                if (value != customerId)
                {
                    customerId = value;
                    OnPropertyChanged("CustomerId");

                }
            }
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

        private string status;

        public string Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged("Status");

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
                    OnPropertyChanged("ID");
                    
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
        private void reSetForm()
        { 
            ID = 0;
            CarId= 0;
            CustomerId= 0;
            BookingPlace = null;
            StartDate= DateTime.Now;
            EndDate= DateTime.Now;
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "ID":
                        if (id <= 0)
                            result = "ID invalid";
                        break;
                    case "CarId":
                        if (CarId <= 0)
                            result = "Car ID invalid";
                        break;
                    case "CustomerId":
                        if (CustomerId <= 0)
                            result = "Customer ID invalid";
                        break;
                    case "BookingPlace":
                        if (string.IsNullOrEmpty(BookingPlace))
                            result = "Booking place cannot be empty";
                        break;
                    case "Status":
                        if (string.IsNullOrEmpty(BookingPlace))
                            result = "Status cannot be empty";
                        break;
                }
                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                    ErrorCollection.Remove(columnName);
                }
                else if (result != null)
                    ErrorCollection.Add(columnName, result);

                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }
        public ObservableCollection<Order> getListObservableOrder()
        {
            List<Order> Orders = orderDao.getListOrder();
            ObservableCollection<Order> OrderList = new ObservableCollection<Order>(Orders);
            return OrderList;
        }
    }
}