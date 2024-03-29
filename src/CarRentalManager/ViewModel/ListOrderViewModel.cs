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
using CarRentalManager.state;

namespace CarRentalManager.ViewModel
{
    public class ListOrderViewModel : BaseViewModel, IDataErrorInfo
    {
        readonly VariableService variableService = new VariableService();
        readonly OrderDAO orderDao = new OrderDAO();
        readonly ContractDAO contractDao = new ContractDAO();
        readonly CommonDAO commonDAO = new CommonDAO();
        readonly CarDAO carDao = new CarDAO();
        readonly CustomerDAO customerDAO = new CustomerDAO();    
        public ObservableCollection<ExtraOrder> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CancelCommand { get; set; }

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
        private string customerName; public string CustomerName { get => customerName; set => SetProperty(ref customerName, value, nameof(CustomerName)); }
        private string customerIdCard; public string CustomerIdCard { get => customerIdCard; set => SetProperty(ref customerIdCard, value, nameof(CustomerIdCard)); }
        private string carName; public string CarName { get => carName; set => SetProperty(ref carName, value, nameof(CarName)); }

        public ListOrderViewModel()
        {
            List = getListObservableOrder();
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand());
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
            ConfirmCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleConfirmCommand());
            SearchCommand = new RelayCommand<object>((p) => { return true; }, (p) => { handleSearchOrder(); });
            CancelCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleCancelOrder());
        }

        private void reSetForm()
        {
            ID = 0;
            CarId = 0;
            CustomerId = 0;
            BookingPlace = null;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            TotalFee = 0;
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
        public ObservableCollection<ExtraOrder> getListObservableOrder()
        {
            List<ExtraOrder> Orders = orderDao.getListExtraOrder();
            ObservableCollection<ExtraOrder> OrderList = new ObservableCollection<ExtraOrder>(Orders);
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
            List = getListObservableOrder();
            MessageBox.Show("Success!");
            OnPropertyChanged(nameof(List));
            reSetForm();
        }

        private Order getOrder(bool isNewOrder)
        {
            int lastOrder = commonDAO.getLastId(ETableName.ORDER);
            Customer currentCustomer = customerDAO.getCustomerByCondition($"idCard = '{CustomerIdCard}'");
            return new Order(isNewOrder ? lastOrder + 1 : ID, CarId, currentCustomer.ID, BookingPlace, StartDate, EndDate, TotalFee,
                    variableService.parseStringToEnum<EOrderStatus>(Status.Substring(38)),
                    DepositAmount.ToString() != null ? DepositAmount : 0,
                    ImageEvidence != null ? ImageEvidence : "",
                    Notes != null ? Notes : "",
                    DateTime.Now, DateTime.Now);
        }

        private void handleAddCommand()
        {
            try
            {
                Order order = getOrder(true);
                Car currentCar = carDao.getCarById(order.CarId.ToString());
                if(carDao.checkIsAvailable(order.StartDate, order.EndDate, currentCar.ID))
                {
                    currentCar.Status = ECarStatus.READYTORENT;
                    orderDao.createOrder(order);
                    updateListUI();
                }
                else
                {
                    MessageBox.Show("The car is not available at that time!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void handleEditCommand()
        {
            Order order = getOrder(false);
            orderDao.updateOrder(order);
            updateListUI();
        }

        private void handleDeleteCommand()
        {
            try
            {
                Order order = orderDao.getOrderById(ID.ToString());
                Car currentCar = carDao.getCarById(order.CarId.ToString());
                currentCar.Status = ECarStatus.AVAILABLE;
                order.Status = EOrderStatus.CANCELBYADMIN;
                carDao.updateCar(currentCar);
                orderDao.updateOrder(order);
                updateListUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void handleConfirmCommand()
        {
            try
            {
                Car currentCar = carDao.getCarById(CarId.ToString());
                Order currentOrder = orderDao.getOrderById(ID.ToString());
                if (currentCar != null)
                {
                    int lastContractID = commonDAO.getLastId(ETableName.CONTRACT);
                    Contract contract = new Contract(lastContractID + 1, ID,
                        LoginInInforState.ID, EContractStatus.UNPAID,
                        TotalFee, currentOrder.DepositAmount,
                        TotalFee - currentOrder.DepositAmount, (int)(currentOrder.DepositAmount / 2), "",
                        EReturnCarStatus.ISNOTRETURN, "", DateTime.Now, DateTime.Now);
                    Order order = getOrder(false);
                    currentCar.Status = ECarStatus.ONRENT;
                    contractDao.createContract(contract);
                    orderDao.updateStatusOfOrder(order);
                    carDao.updateCar(currentCar);

                    updateListUI();
                }
                else
                {
                    MessageBox.Show("The Car is onrent or not available to rent for now");
                }
            }
            catch
            {
                MessageBox.Show("Cannot remove order");
            }
        }
        private void handleSearchOrder()
        {
            try
            {
                Order order = orderDao.getOrderById(ID.ToString());
                if (order != null)
                {
                    CarId = order.CarId;
                    BookingPlace = order.BookingPlace;
                    StartDate = order.StartDate;
                    EndDate = order.EndDate;
                }
                else
                {
                    MessageBox.Show("The Id of Order is not found");
                }
            }
            catch
            {
                MessageBox.Show("The Id of Order is not found");
            }
        }

        private void handleCancelOrder()
        {
            try
            {
                Order order = orderDao.getOrderById(ID.ToString());
                order.Status = EOrderStatus.CANCELBYUSER;

                Car currentCar = carDao.getCarById(order.CarId.ToString());
                currentCar.Status = ECarStatus.AVAILABLE;

                carDao.updateCar(currentCar);
                orderDao.updateOrder(order);
                updateListUI();
            }
            catch
            {
                MessageBox.Show("Server is not available at this time");
            }
        }
    }
}