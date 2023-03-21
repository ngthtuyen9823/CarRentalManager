using CarRentalManager.dao;
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
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Collections;

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
                if (ErrorCollection.Count>0)
                    return false;
                else
                    return true;
            }, (p) =>
            {
                int lastOrderId = commonDAO.getLastId(ETableName.ORDER);
                int lastCustomerId = commonDAO.getLastId(ETableName.CUSTOMER);

                customerDAO.createNewCustomer(lastCustomerId + 1, 
                    PhoneNumber, 
                    Name, 
                    Email != null ? Email : "", 
                    IdCard != null ? IdCard : "", 
                    BookingPlace, 
                    ImageIdCardFront != null ? ImageIdCardFront : "", 
                    ImageIdCardBack != null ? ImageIdCardBack : "");

                orderDAO.addOrderToList(lastOrderId + 1, 
                    variableService.parseStringToInt(CarId), 
                    lastCustomerId + 1, 
                    BookingPlace, StartDate, EndDate, TotalFee,
                    DepositAmount.ToString() != null ? DepositAmount : 0,
                    ImageEvidence != null ? ImageEvidence : "",
                    Notes != null ? Notes : "");

                resetForm();

            });
        }

        public void handleRegister()
        {
            //1 Add customer


        }

        private void resetForm()
        {
            Name = null;
            PhoneNumber = null;
            BookingPlace = null;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
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
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                if (value != address)
                {
                    address = value;
                    OnPropertyChanged("Address");
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
                if (value !=updatedAt)
                {
                    createdAt = value;
                    OnPropertyChanged("UpdatedAt");
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
        private string imageIdCardFront;

        public string ImageIdCardFront
        {
            get { return imageIdCardFront; }
            set
            {
                if (value != imageIdCardFront)
                {
                    imageIdCardFront = value;
                    OnPropertyChanged("imageIdCardFront");
                }
            }
        }
        private string imageIdCardBack;

        public string ImageIdCardBack
        {
            get { return imageIdCardBack; }
            set
            {
                if (value != imageIdCardBack)
                {
                    imageIdCardBack = value;
                    OnPropertyChanged("imageIdCardBack");
                }
            }
        }
        private int depositAmount;

        public int DepositAmount
        {
            get { return depositAmount; }
            set
            {
                if (value != depositAmount)
                {
                    depositAmount = value;
                    OnPropertyChanged("depositAmount");
                }
            }
        }
        private string imageEvidence;

        public string ImageEvidence
        {
            get { return imageEvidence; }
            set
            {
                if (value != imageEvidence)
                {
                    imageEvidence = value;
                    OnPropertyChanged("depositAmount");
                }
            }
        }
        private string notes;

        public string Notes
        {
            get { return notes; }
            set
            {
                if (value != notes)
                {
                    notes = value;
                    OnPropertyChanged("notes");
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
                    case "PhoneNumber":
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
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                            result = "Name cannot be empty";
                        //ErrorCollection.Remove(name);
                        break;
                    case "BookingPlace":
                        if (string.IsNullOrEmpty(BookingPlace))
                            result = "Address cannot be empty";
                        //ErrorCollection.Remove(name);
                        break;
                }
                if (ErrorCollection.ContainsKey(name))
                {
                    ErrorCollection[name] = result;
                    ErrorCollection.Remove(name);
                }
                else if (result != null)
                    ErrorCollection.Add(name, result);

                OnPropertyChanged("ErrorCollection");
                return result;
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
