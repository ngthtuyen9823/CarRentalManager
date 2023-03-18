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

namespace CarRentalManager.ViewModel
{
    public class RegistrationVM : BaseViewModel, IDataErrorInfo
    {
        public ObservableCollection<Order> List { get; set; }
        public string Error { get { return null; } }
        private string _username;
        readonly VariableService variableService = new VariableService();
        public ICommand RegisterCommand { get; set; }
        readonly OrderDAO orderDAO= new OrderDAO();
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public RegistrationVM() 
        {
            List = getListObservableOrder();
            RegisterCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                int lastOrderId = orderDAO.getLastId(ETableName.ORDER);
                int lastOrderIdCustomer = orderDAO.getLastId(ETableName.CUSTOMER);

                orderDAO.addOrderToList(lastOrderId+1, variableService.parseStringToInt(CarId), lastOrderIdCustomer, BookingPlace, StartDate, EndDate, TotalFee);



                //int lastOrderId = orderDAO.getLastId(ETableName.ORDER);
                //MessageBox.Show(String.Format("Da vao: {0}", lastOrderIdCustomer.ToString()));


                //MessageBox.Show(String.Format("Da vao: {0}", BookingPlace));

                //MessageBox.Show(String.Format("Da vao: {0}", StartDate.ToString()));
                //MessageBox.Show(String.Format("Da vao: {0}", EndDate.ToString()));

                //MessageBox.Show(String.Format("Da vao: {0}", Name));
                //MessageBox.Show(String.Format("Da vao: {0}", PhoneNumber));
                //MessageBox.Show(String.Format("Da vao: {0}", TotalFee));
                //MessageBox.Show(String.Format("CarID: {0}", CarId));




            });
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
