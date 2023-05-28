using CarRentalManager.models;
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
using CarRentalManager.state;

namespace CarRentalManager.ViewModel
{
    public class ListContractViewModel : BaseViewModel
    {
        readonly VariableService variableService = new VariableService();
        readonly ContractDAO contractDAO = new ContractDAO();
        readonly OrderDAO orderDAO = new OrderDAO();
        readonly CarDAO carDAO = new CarDAO();
        readonly CommonDAO commonDAO = new CommonDAO();
        public string Error { get { return null; } }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        private ObservableCollection<ExtraContract> list;
        public ObservableCollection<ExtraContract> List { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand PayCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        private bool isOpenPopupCarInfor;
        public bool IsOpenPopupCarInfor { get { return isOpenPopupCarInfor; } set { isOpenPopupCarInfor = value; OnPropertyChanged(); } }
        public ICommand ClosePopupCarInforCommand { get; set; }
        public ICommand OpenPopupCommand { get; set; }
        //*INFO: Value binding
        private int id; public int ID { get => id; set => SetProperty(ref id, value, nameof(ID)); }
        private int orderId; public int OrderId { get => orderId; set => SetProperty(ref orderId, value, nameof(OrderId)); }
        private int userId; public int UserId { get => userId; set => SetProperty(ref userId, value, nameof(UserId)); }
        private int price; public int Price { get => price; set => SetProperty(ref price, value, nameof(Price)); }
        private string status; public string Status { get => status; set => SetProperty(ref status, value, nameof(Status)); }
        private int fee; public int Fee { get => fee; set => SetProperty(ref fee, value, nameof(Fee)); }
        private int paid; public int Paid { get => paid; set => SetProperty(ref paid, value, nameof(Paid)); }
        private int remain; public int Remain { get => remain; set => SetProperty(ref remain, value, nameof(Remain)); }
        private int receivedFee; public int ReceivedFee { get => receivedFee; set => SetProperty(ref receivedFee, value, nameof(ReceivedFee)); }
        private string returnCarStatus; public string ReturnCarStatus { get => returnCarStatus; set => SetProperty(ref returnCarStatus, value, nameof(ReturnCarStatus)); }
        private string feedback; public string Feedback { get => feedback; set => SetProperty(ref feedback, value, nameof(Feedback)); }
        private string note; public string Note { get => note; set => SetProperty(ref note, value, nameof(Note)); }
        private string customerName; public string CustomerName { get => customerName; set => SetProperty(ref customerName, value, nameof(CustomerName)); }
        private string customerIdCard; public string CustomerIdCard { get => customerIdCard; set => SetProperty(ref customerIdCard, value, nameof(CustomerIdCard)); }
        private string customerPhone; public string CustomerPhone { get => customerPhone; set => SetProperty(ref customerPhone, value, nameof(CustomerPhone)); }


        public ListContractViewModel(bool isAdmin)
        {
            List = isAdmin ? getListObservableContract() : getSupplierListObservableContract(LoginInInforState.ID.ToString());
            AddCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleAddCommand());
            EditCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleEditCommand());
            DeleteCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handleDeleteCommand());
            PayCommand = new RelayCommand<object>((p) => checkIsError(), (p) => handlePayCommand());
            IsOpenPopupCarInfor = false;
            ClosePopupCarInforCommand = new RelayCommand<object>((o) => { return true; }, (o) => handleClosePopupCommand());
            OpenPopupCommand = new RelayCommand<string>((content) => { return true; }, (content) => handleOpenPopupCommand());
        }
        private void reSetForm()
        {
            ID = 0;
            OrderId = 0;
            UserId = 0;
            Status = null;
            Fee = 0;
        }
       
        public ObservableCollection<ExtraContract> getListObservableContract()
        {
            List<ExtraContract> contracts = contractDAO.getListExtraContract();
            ObservableCollection<ExtraContract> contractList = new ObservableCollection<ExtraContract>(contracts);
            return contractList;
        }
        public ObservableCollection<ExtraContract> getSupplierListObservableContract(string supplierId)
        {
            List<int> orderId = commonDAO.getListOrderId(supplierId);
            List<ExtraContract> contracts = contractDAO.getListContractByOrderId(orderId);
            ObservableCollection<ExtraContract> contractList = contracts != null ? new ObservableCollection<ExtraContract>(contracts) : null;
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
            return new Contract
            {
                ID = id,
                OrderId = OrderId,
                UserId = UserId,
                Status = Status.Substring(38),
                Price = Price,
                Paid = Paid,
                Remain = Remain,
                ReceivedFee = ReceivedFee,
                Feedback = Feedback,
                ReturnCarStatus = ReturnCarStatus.Substring(38),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
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

        private void updateContract(Contract currentContract)
        {
            currentContract.Paid += fee;
            currentContract.Remain -= fee;
            currentContract.ReceivedFee = (int)(currentContract.Paid / 2);
            currentContract.Remain = currentContract.Remain < 0 ? 0 : currentContract.Remain;
            currentContract.Status = currentContract.Remain == 0 ? EContractStatus.COMPLETE.ToString() : EContractStatus.PAID.ToString();
            currentContract.Feedback = Feedback;
            currentContract.ReturnCarStatus = ReturnCarStatus;
            currentContract.Note = Note;
            contractDAO.updateContract(currentContract);
        }
        private void handlePayCommand()
        {
            try
            {
                bool isError = Fee <= 0; 
                if (!isError)
                {
                    IsOpenPopupCarInfor = false;
                    Contract currentContract = contractDAO.getContractById(ID.ToString());
                    Order currentOrder = orderDAO.getOrderById(currentContract.OrderId.ToString());
                    Car currentCar = carDAO.getCarById(currentOrder.CarId.ToString());
                    this.updateContract(currentContract);
                    if (currentContract.Status.Trim() == EContractStatus.COMPLETE.ToString())
                        currentCar.Status = ECarStatus.AVAILABLE.ToString();
                    if (currentContract.ReturnCarStatus.Trim() == EReturnCarStatus.BROKEN.ToString())
                        currentCar.Status = ECarStatus.UNAVAILABLE.ToString();
                    carDAO.updateCar(currentCar);
                    contractDAO.updateContract(currentContract);
                    updateListUI();
                }
                else
                {
                    IsOpenPopupCarInfor = false;
                    MessageBox.Show("The contract has been paid completely");
                }
            }
            catch
            {
                MessageBox.Show(Error);
            }
        }
        private void handleClosePopupCommand()
        {
            IsOpenPopupCarInfor = false;
        }

        private void handleOpenPopupCommand()
        {
            if (Status is null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng để thanh toán!");
            }
            else
            {
                bool isError = variableService.parseStringToEnum<EContractStatus>(Status.Substring(38)) == EContractStatus.COMPLETE;
                if (!isError)
                {
                    IsOpenPopupCarInfor = true;
                }
                else
                {
                    MessageBox.Show("The contract was paid completely");
                }
            }
        }
    }
}
