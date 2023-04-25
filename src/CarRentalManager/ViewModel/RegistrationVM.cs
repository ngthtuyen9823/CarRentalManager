using CarRentalManager.dao;
using CarRentalManager.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Input;
using CarRentalManager.enums;
using CarRentalManager.services;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace CarRentalManager.ViewModel
{
    public class RegistrationVM : BaseViewModel, IDataErrorInfo
    {
        public ObservableCollection<Order> List { get; set; }
        public string Error { get { return null; } }
        public ICommand RegisterCommand { get; set; }
        readonly OrderDAO orderDAO= new OrderDAO();
        readonly CommonDAO commonDAO = new CommonDAO();
        readonly CustomerDAO customerDAO = new CustomerDAO();
        readonly CarDAO carDAO = new CarDAO();
        readonly VariableService variableService = new VariableService();
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        //*INFO: Value binding
        private string address; public string Address { get => address; set => SetProperty(ref address, value, nameof(Address)); }
        private int totalFee; public int TotalFee { get => totalFee; set => SetProperty(ref totalFee, value, nameof(TotalFee)); }
        private string bookingPlace; public string BookingPlace { get => bookingPlace; set => SetProperty(ref bookingPlace, value, nameof(BookingPlace)); }
        private DateTime startDate; public DateTime StartDate { get => startDate; set => SetProperty(ref startDate, value, nameof(StartDate)); }
        private DateTime endDate; public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value, nameof(EndDate)); }
        private string name; public string Name { get => name; set => SetProperty(ref name, value, nameof(Name)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private string phoneNumber; public string PhoneNumber { get => phoneNumber; set => SetProperty(ref phoneNumber, value, nameof(PhoneNumber)); }
        private int carId; public int CarId { get => carId; set => SetProperty(ref carId, value, nameof(CarId)); }
        private string email; public string Email { get => email; set => SetProperty(ref email, value, nameof(Email)); }
        private string idCard; public string IdCard { get => idCard; set => SetProperty(ref idCard, value, nameof(IdCard)); }
        private string imageIdCardFront; public string ImageIdCardFront { get => imageIdCardFront; set => SetProperty(ref imageIdCardFront, value, nameof(ImageIdCardFront)); }
        private string imageIdCardBack; public string ImageIdCardBack { get => imageIdCardBack; set => SetProperty(ref imageIdCardBack, value, nameof(ImageIdCardBack)); }
        private int depositAmount; public int DepositAmount { get => depositAmount; set => SetProperty(ref depositAmount, value, nameof(DepositAmount)); }
        private string imageEvidence; public string ImageEvidence { get => imageEvidence; set => SetProperty(ref imageEvidence, value, nameof(ImageEvidence)); }
        private string notes; public string Notes { get => notes; set => SetProperty(ref notes, value, nameof(Notes)); }

        
        
        public RegistrationVM() 
        {
            RegisterCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => handleRegisterCommand());
        }

        private void resetForm()
        {
            Name = null;
            PhoneNumber = null;
            BookingPlace = null;
            IdCard= null;
            ImageIdCardFront = null;
            ImageIdCardBack = null;
            DepositAmount = 0;
            ImageEvidence = null;
            Notes= null;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            TotalFee = 0;
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case nameof(PhoneNumber):
                        if (string.IsNullOrWhiteSpace(PhoneNumber))
                            result = "Phone Number cannot be empty";
                        else
                        {
                            Regex validatePhoneNumberRegex = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
                            if (!validatePhoneNumberRegex.IsMatch(PhoneNumber))
                                result = "not exist";
                        }
                        //ErrorCollection.Remove(name);
                        break;
                    default:
                        if (string.IsNullOrEmpty(typeof(RegistrationVM).GetProperty(columnName).GetValue(this)?.ToString()))
                            result = string.Format("{0} can not be empty", columnName);
                        //ErrorCollection.Remove(name);
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

        private Customer getCustomer(int lastCustomerId)
        {
            return new Customer(lastCustomerId + 1,
                    PhoneNumber,
                    Name,
                    Email != null ? Email : "",
                    IdCard,
                    BookingPlace,
                    ImageIdCardFront != null ? ImageIdCardFront : "",
                    ImageIdCardBack != null ? ImageIdCardBack : "",
                    DateTime.Now, DateTime.Now);
        }

        private Order getOrder(int lastOrderId, int lastCustomerId)
        {
            return new Order(lastOrderId + 1,
                    CarId,
                    lastCustomerId + 1,
                    BookingPlace, StartDate, EndDate, TotalFee, 
                    EOrderStatus.PENDING,
                    DepositAmount,
                    ImageEvidence != null ? ImageEvidence : "",
                    Notes != null ? Notes : "",
                    DateTime.Now, DateTime.Now);
        }

        private void handleRegisterCommand()
        {
            int lastOrderId = commonDAO.getLastId(ETableName.ORDER);
            int lastCustomerId = commonDAO.getLastId(ETableName.CUSTOMER);
            Customer customer = getCustomer(lastCustomerId);
            Order Order = getOrder(lastOrderId, lastCustomerId);

            customerDAO.createCustomer(customer);
            orderDAO.createOrder(Order);
            MessageBox.Show("Success!");

            resetForm();
        }
    }
}
