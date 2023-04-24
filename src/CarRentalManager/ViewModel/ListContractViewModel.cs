﻿using CarRentalManager.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CarRentalManager.dao;
using System.Windows.Input;
using System.ComponentModel;
using CarRentalManager.enums;
using CarRentalManager.services;
using MaterialDesignThemes.Wpf;
using System.Net;
using System.Xml.Linq;
using System.Windows;
using System.Data.Entity.Core.Objects;

namespace CarRentalManager.ViewModel
{
    public class ListContractViewModel : BaseViewModel, IDataErrorInfo
    {
        readonly VariableService variableService = new VariableService();
        readonly ContractDAO contractDAO = new ContractDAO();
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<Contract> list;
        public ObservableCollection<Contract> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand PayCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }


        //*INFO: Value binding
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private int orderId; public int OrderId { get => orderId; set => SetProperty(ref orderId, value, nameof(OrderId)); }
        private int userId; public int UserId { get => userId; set => SetProperty(ref userId, value, nameof(UserId)); }
        private int price; public int Price { get => price; set => SetProperty(ref price, value, nameof(Price)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private int fee; public int Fee { get => fee; set => SetProperty(ref fee, value, nameof(Fee)); }
        private int paid; public int Paid { get => paid; set => SetProperty(ref paid, value, nameof(Paid)); }
        private int remain; public int Remain { get => remain; set => SetProperty(ref remain, value, nameof(Remain)); }


        public ListContractViewModel()
        {
            List = getListObservableContract();
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand());
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
            PayCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handlePayCommand());
        }
        private void reSetForm()
        {
            ID = 0;
            OrderId = 0;
            UserId = 0;
            Status = null;
            Fee = 0;
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
                            result = "Invalid ID";
                        break;
                    case nameof(OrderId):
                        if (OrderId <= 0)
                            result = "Invalid order ID";
                        break;
                    case nameof(UserId):
                        if (UserId <= 0)
                            result = "Invalid user ID";
                        break;
                    case nameof(Fee):
                        if (Fee <= 0)
                            result = "Please enter fee to pay";
                        break;
                    default:
                        if (string.IsNullOrEmpty(typeof(ListContractViewModel).GetProperty(columnName).GetValue(this)?.ToString()))
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

        public ObservableCollection<Contract> getListObservableContract()
        {
            List<Contract> contracts = contractDAO.getListContract();
            ObservableCollection<Contract> contractList = new ObservableCollection<Contract>(contracts);
            return contractList;
        }
        private bool checkIsError()
        {
            if (ErrorCollection.Count > 0)
                return false;
            else
                return true;
        }
        private Contract getContract()
        {
            return new Contract(ID, OrderId, UserId,
                    variableService.parseStringToEnum<EContractStatus>(Status.Substring(38)),
                    Price, Paid, Remain,
                    DateTime.Now, DateTime.Now);
        }

        private void updateListUI()
        {
            MessageBox.Show("Success!");
            List = getListObservableContract();
            OnPropertyChanged(nameof(List));
            reSetForm();
        }

        private void handleAddCommand()
        {
            Contract contract = getContract();
            contractDAO.createContract(contract);
            updateListUI();
        }

        private void handleEditCommand()
        {
            Contract contract = getContract();
            contractDAO.updateContract(contract);
            updateListUI();
        }

        private void handleDeleteCommand()
        {
            contractDAO.removeContract(ID);
            updateListUI();
        }
        private void handlePayCommand()
        {
            try
            {
                bool isError = Fee <= 0 || 
                    variableService.parseStringToEnum<EContractStatus>(Status.Substring(38)) == EContractStatus.COMPLETE;
                if (!isError)
                {
                    Contract currentContract = contractDAO.getContractById(ID.ToString());
                    currentContract.Paid += Fee;
                    currentContract.Remain -= Fee;
                    currentContract.Remain = currentContract.Remain < 0 ? 0 : currentContract.Remain;
                    currentContract.Status = currentContract.Remain == 0 ? EContractStatus.COMPLETE : EContractStatus.PAID;
                    contractDAO.updateContract(currentContract);
                    updateListUI();
                }
                else
                {
                    MessageBox.Show("The contract has been paid completely");
                }
            }
            catch
            {
                MessageBox.Show(Error);
            }
        }
    }
}
