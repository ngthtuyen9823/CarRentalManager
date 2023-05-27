using CarRentalManager.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CarRentalManager.dao;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using CarRentalManager.services;
using CarRentalManager.enums;

namespace CarRentalManager.ViewModel
{
    public class ListCustomerViewModel : BaseViewModel, IDataErrorInfo
    {
        readonly ImageService imgService = new ImageService();
        readonly CustomerDAO customerDAO = new CustomerDAO();
        readonly CommonDAO commonDAO = new CommonDAO();
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<Customer> list;
        public ObservableCollection<Customer> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        //*INFO: Value binding
        private string name; public string Name { get => name; set => SetProperty(ref name, value, nameof(Name)); }
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private string phoneNumber; public string PhoneNumber { get => phoneNumber; set => SetProperty(ref phoneNumber, value, nameof(PhoneNumber)); }
        private string email; public string Email { get => email; set => SetProperty(ref email, value, nameof(Email)); }
        private string address; public string Address { get => address; set => SetProperty(ref address, value, nameof(Address)); }
        private string idCard; public string IdCard { get => idCard; set => SetProperty(ref idCard, value, nameof(IdCard)); }
        private string imageIdCardFront; public string ImageIdCardFront { get => imageIdCardFront; set => SetProperty(ref imageIdCardFront, value, nameof(ImageIdCardFront)); }
        private string imageIdCardBack; public string ImageIdCardBack { get => imageIdCardBack; set => SetProperty(ref imageIdCardBack, value, nameof(ImageIdCardBack)); }
        

        public ListCustomerViewModel() 
        {
            List = getListObservableCustomer();
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand());
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
        }
        
        private void reSetForm()
        {
            ID = 0;
            Name = null;
            PhoneNumber = null;
            Email= null;
            IdCard= null;
            Address= null;
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
                    default:
                        if (string.IsNullOrEmpty(typeof(ListCustomerViewModel).GetProperty(columnName).GetValue(this)?.ToString()))
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
        public ObservableCollection<Customer> getListObservableCustomer()
        {
            List<Customer> customers = customerDAO.getListCustomer();
            ObservableCollection<Customer> customerList = new ObservableCollection<Customer>(customers);
            return customerList;
        }
        private bool checkIsError()
        {
            if (ErrorCollection.Count > 0)
                return false;
            else
                return true;
        }
        private Customer getCustomer(bool isNewCustomer)
        {
            int lastCustomer = commonDAO.getLastId(ETableName.CUSTOMER);
            ImageIdCardFront = imgService.getProjectImagePath(ImageIdCardFront ?? "", "customers", (lastCustomer + 1).ToString());
            ImageIdCardFront = imgService.getProjectImagePath(ImageIdCardBack ?? "", "customers", (lastCustomer + 1).ToString());
            return new Customer
            {
                ID = isNewCustomer ? lastCustomer + 1 : ID,
                PhoneNumber = PhoneNumber,
                Name = Name,
                Email = Email,
                IdCard = IdCard,
                Address = Address,
                ImageIdCardBack = ImageIdCardBack != null ? ImageIdCardBack : "",
                imageIdCardBack = ImageIdCardBack != null ? ImageIdCardBack : "",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,

            };
        }

        private void updateListUI()
        {
            MessageBox.Show("Success!");
            List = getListObservableCustomer();
            OnPropertyChanged(nameof(List));
            reSetForm();
        }

        private void handleAddCommand()
        {
            Customer customer = getCustomer(true);
            customerDAO.createCustomer(customer);
            updateListUI();
        }

        private void handleEditCommand()
        {
            Customer customer = getCustomer(false);
            customerDAO.updateCustomer(customer);
            updateListUI();
        }

        private void handleDeleteCommand()
        {
            customerDAO.removeCustomer(ID);
            updateListUI();
        }
    }
}
