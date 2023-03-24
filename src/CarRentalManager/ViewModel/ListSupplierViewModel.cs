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
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Collections;
using CarRentalManager.enums;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;

namespace CarRentalManager.ViewModel
{
    public class ListSupplierViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<Supplier> list;
        public ObservableCollection<Supplier> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        readonly SupplierDAO supplierDAO = new SupplierDAO();
        public ListSupplierViewModel()
        {
            List = getListObservableSupplier();
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (ErrorCollection.Count > 0)
                    return false;
                else
                    return true;
            }, (p) =>
            {
                supplierDAO.addSupplierToList(ID, Name, PhoneNumber, Email, Address);
                List = getListObservableSupplier();
                OnPropertyChanged(nameof(List));
                reSetForm();
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
        private void reSetForm()
        {
            ID = 0;
            Name = null;
            PhoneNumber = null;
            Email = null;
            Address = null;
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Name":
                        if (string.IsNullOrEmpty(Name))
                            result = "Name cannot be empty";
                        break;
                    case "PhoneNumber":
                        if (string.IsNullOrEmpty(PhoneNumber))
                            result = "Phone number cannot be empty";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                            result = "Email cannot be empty";
                        break;
                    case "ID":
                        if (ID <= 0)
                            result = "ID invalid";
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(Address))
                            result = "Address can not be empty";
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
        public ObservableCollection<Supplier> getListObservableSupplier()
        {
            List<Supplier> suppliers = supplierDAO.getListSupplier();
            ObservableCollection<Supplier> supplierList = new ObservableCollection<Supplier>(suppliers);
            return supplierList;
        }

    }
}
