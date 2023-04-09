using CarRentalManager.models;
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
using CarRentalManager.services;
using MaterialDesignThemes.Wpf;
using System.Net;

namespace CarRentalManager.ViewModel
{
    public class ListOrderViewModel : BaseViewModel, IDataErrorInfo
    {
        readonly VariableService variableService = new VariableService();
        readonly OrderDAO orderDao = new OrderDAO();

        public ObservableCollection<Order> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        //*INFO: Value binding
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private int carId; public int CarId { get => carId; set => SetProperty(ref carId, value, nameof(CarId)); }
        private int customerId; public int CustomerId { get => customerId; set => SetProperty(ref customerId, value, nameof(CustomerId)); }
        private int totalFee; public int TotalFee { get => totalFee; set => SetProperty(ref totalFee, value, nameof(TotalFee)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private string bookingPlace; public string BookingPlace { get => bookingPlace; set => SetProperty(ref bookingPlace, value, nameof(BookingPlace)); }
        private DateTime startDate; public DateTime StartDate { get => startDate; set => SetProperty(ref startDate, value, nameof(StartDate)); }
        private DateTime endDate; public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value, nameof(EndDate)); }
        private int depositAmount; public int DepositAmount { get => depositAmount; set => SetProperty(ref depositAmount, value, nameof(DepositAmount)); }
        private string imageEvidence; public string ImageEvidence { get => imageEvidence; set => SetProperty(ref imageEvidence, value, nameof(ImageEvidence)); }
        private string notes; public string Notes { get => notes; set => SetProperty(ref notes, value, nameof(Notes)); }


        public ListOrderViewModel()
        {
            List = getListObservableOrder();
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand()); 
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
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
                    case nameof(ID):
                        if (ID <= 0)
                            result = "ID invalid";
                        break;
                    case nameof(CarId):
                        if (CarId <= 0)
                            result = "Car ID invalid";
                        break;
                    case nameof(CustomerId):
                        if (CustomerId <= 0)
                            result = "Customer ID invalid";
                        break;
                    default:
                        if (string.IsNullOrEmpty(typeof(ListOrderViewModel).GetProperty(columnName).GetValue(this)?.ToString()))
                            result = string.Format("{0} can not be empty", columnName);
                        break;
                }
                if (ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                    ErrorCollection.Remove(columnName);
                }
                else if (result != null)
                    ErrorCollection.Add(columnName, result);

                OnPropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }
        public ObservableCollection<Order> getListObservableOrder()
        {
            List<Order> Orders = orderDao.getListOrder();
            ObservableCollection<Order> OrderList = new ObservableCollection<Order>(Orders);
            return OrderList;
        }
        
        private bool checkIsError()
        {
            if (ErrorCollection.Count > 0)
                return false;
            else
                return true;
        }
        private void updateListUI()
        {
            MessageBox.Show("Success!");
            List = getListObservableOrder();
            OnPropertyChanged(nameof(List));
            reSetForm();
        }

        private Order getOrder()
        {
            return new Order(ID, CarId, CustomerId, BookingPlace, StartDate, EndDate, TotalFee,
                    variableService.parseStringToEnum<EOrderStatus>(Status.Substring(38)),
                    DepositAmount.ToString() != null ? DepositAmount : 0,
                    ImageEvidence != null ? ImageEvidence : "",
                    Notes != null ? Notes : "",
                    DateTime.Now, DateTime.Now);
        }

        private void handleAddCommand()
        {
            Order order = getOrder();
            orderDao.createOrder(order);
            updateListUI();
        }

        private void handleEditCommand()
        {
            Order order = getOrder();
            orderDao.updateOrder(order);
            updateListUI();
        }

        private void handleDeleteCommand()
        {
            orderDao.removeOrder(ID);
            updateListUI();
        }
    }
}