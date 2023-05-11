using CarRentalManager.state;
using CarRentalManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarRentalManager.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool isLoaded = false;
        public ICommand CustomerCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand ContractCommand { get; set; }
        public ICommand CarCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand RegisterFormCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand StatisticCommand { get; set; }
        private BaseViewModel currentChildView;
        public BaseViewModel CurrentChildView { get { return currentChildView; } set { currentChildView = value; OnPropertyChanged(nameof(currentChildView)); } }
        public MainViewModel()
        {
            ExecuteShowHomeViewCommand(null);
            SetCommands();
        }
        private void SetCommands()
        {
            CarCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new ListCarViewModel(true); });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new ListCustomerViewModel(); });
            ContractCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new ListContractViewModel(); });
            OrderCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new ListOrderViewModel(); });
            SupplierCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new ListSupplierViewModel(); });
            HomeCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new HomeViewModel(); });
            StatisticCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new StatisticViewModel(); });

        }
        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
        }
    }
}