using CarRentalManager.modals;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CarRentalManager.dao;
using System;
using System.Windows.Input;
using CarRentalManager.enums;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Media;
using System.Xml.Linq;
using System.Windows;

namespace CarRentalManager.ViewModel
{
    public class ListContractViewModel : BaseViewModel
    {
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
 
        public ObservableCollection<Contract> getListObservableContract()
        {
            List<Contract> contracts = contractDAO.getListContract();
            ObservableCollection<Contract> contractList = new ObservableCollection<Contract>(contracts);
            return contractList;
        }
    }
}
