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
    public class ListOrderViewModel : BaseViewModel, IDataErrorInfo
    {
        public ObservableCollection<Order> List { get; set; }
        public ICommand AddCommand { get; set; }

        readonly OrderDAO orderDao = new OrderDAO();

        /*public void InvalidateRequerySuggested();*/
        public ListOrderViewModel()
        {
            List = getListObservableOrder();
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (ID == 0 || CarId == 0 || CustomerId == 0 || BookingPlace == null || Status == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }, (p) =>
            {
                orderDao.addOrderToList(ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee);
                List = getListObservableOrder();
                OnPropertyChanged(nameof(List));
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
        private string error;
        public string Error
        {
            get => error;
            set
            {
                if (error != value)
                {
                    error = value;
                    RaisePropertyChanged("Error");
                }
            }
        }

        private void RaisePropertyChanged(string v)
        {

        }

        public string this[string columnName]
        {
            get
            {
                return OnValidate(columnName);
            }
        }

        private string OnValidate(string columnName)
        {
            string result = string.Empty;
            if (columnName == "BookingPlace")
            {
                if (string.IsNullOrEmpty(BookingPlace))
                {
                    result = "BookingPlace is Required";
                }
            }
            if (columnName == "Status")
            {
                if (string.IsNullOrEmpty(BookingPlace))
                {
                    result = "Status is Required";
                }
            }
            if (columnName == "ID")
            {
                if (ID == 0 || string.IsNullOrEmpty(ID.ToString()))
                {
                    result = "ID invalid";
                }
            }
            if (columnName == "CarId")
            {
                if (CarId == 0 || string.IsNullOrEmpty(CarId.ToString()))
                {
                    result = "CarID invalid";
                }
            }

            if (columnName == "CustomerId")
            {
                if (CustomerId == 0 || string.IsNullOrEmpty(CustomerId.ToString()))
                {
                    result = "CustomerID invalid";
                }
            }
            if (result == null)
            {
                Error = null;
            }
            else
            {
                Error = "Error";
            }
            return result;
        }
        public ObservableCollection<Order> getListObservableOrder()
        {
            List<Order> Orders = orderDao.getListOrder();
            ObservableCollection<Order> OrderList = new ObservableCollection<Order>(Orders);
            return OrderList;
        }
    }
}