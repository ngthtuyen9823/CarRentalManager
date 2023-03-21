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
using System.Xml.Linq;

namespace CarRentalManager.ViewModel
{
    public class ListContractViewModel : BaseViewModel, IDataErrorInfo
    {
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<Contract> list;
        public ObservableCollection<Contract> List { get; set; }
        public ICommand AddCommand { get; set; }
        readonly ContractDAO contractDAO = new ContractDAO();
        public ListContractViewModel()
        {
            List = getListObservableContract();
            AddCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                contractDAO.addContractToList(ID, OrderId, UserId, MakingDay, CreatedAt, UpdatedAt);
                List = getListObservableContract();
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
                    OnPropertyChanged("ID");
                }
            }
        }
        private int orderId;

        public int OrderId
        {
            get { return orderId; }
            set
            {
                if (value != orderId)
                {
                    orderId = value;
                    OnPropertyChanged("OrderId");

                }
            }
        }
        private int userId;

        public int UserId
        {
            get { return userId; }
            set
            {
                if (value != userId)
                {
                    userId = value;
                    OnPropertyChanged("UserId");
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
        private DateTime makingDay;

        public DateTime MakingDay
        {
            get { return makingDay; }
            set
            {
                if (value != makingDay)
                {
                    makingDay = value;
                    OnPropertyChanged("MakingDay");
                }
            }
        }
        private void reSetForm()
        {
            ID = 0;
            OrderId = 0;
            UserId = 0;
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "ID":
                        if (ID == 0)
                            result = "Invalid ID";
                        break;
                    case "OrderId":
                        if (OrderId == 0)
                            result = "Invalid order ID";
                        break;
                    case "UserId":
                        if (UserId == 0)
                            result = "Invalid user ID";
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

        public ObservableCollection<Contract> getListObservableContract()
        {
            List<Contract> contracts = contractDAO.getListContract();
            ObservableCollection<Contract> contractList = new ObservableCollection<Contract>(contracts);
            return contractList;
        }
    }
}
