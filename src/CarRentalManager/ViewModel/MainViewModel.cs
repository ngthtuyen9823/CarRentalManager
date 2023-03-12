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
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ContractCommand { get; set; }
        public ICommand CarCommand { get; set; }
        public ICommand OrderCommand { get; set; }




        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                isLoaded = true;
                if (p == null)
                {
                    return;
                }
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                if (loginWindow.DataContext == null)
                {
                    return;
                }
                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.isLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });
          
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wd = new CustomerWindow(); wd.ShowDialog(); });
            ContractCommand = new RelayCommand<object>((p) => { return true; }, (p) => { ContractWindow wd = new ContractWindow(); wd.ShowDialog(); });
            CarCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CarWindow wd = new CarWindow(); wd.ShowDialog(); });
            OrderCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OrderWindow wd = new OrderWindow(); wd.ShowDialog(); });


            //var a = DataProvider.Ins.DB.Cars.ToList();
        }
    }
}