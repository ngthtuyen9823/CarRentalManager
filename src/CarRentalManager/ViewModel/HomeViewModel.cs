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
    public class HomeViewModel : BaseViewModel
    {
        public ICommand StatisticCommand { get; set; }
        private BaseViewModel currentChildView;

        public BaseViewModel CurrentChildView { get { return currentChildView; } set { currentChildView = value; OnPropertyChanged(nameof(currentChildView)); } }
        public HomeViewModel()
        {
            SetCommands();
        }
        private void SetCommands()
        {
            StatisticCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new StatisticViewModel(); });
        }
    }
}