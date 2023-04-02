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
        public ICommand SupplierCommand { get; set; }

        public ICommand ContractCommand { get; set; }
        public ICommand CarCommand { get; set; }
        public ICommand OrderCommand { get; set; }
        public ICommand RegisterFormCommand { get; set; }
        public BaseViewModel CurrentChildView { get { return currentChildView; } set { currentChildView = value; OnPropertyChanged(nameof(currentChildView)); } }
        public string CapTion { get { return capTion; } set { capTion = value; OnPropertyChanged(nameof(capTion)); } }

        private BaseViewModel currentChildView;
        private string capTion;
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                //isLoaded = true;
                //if (p == null)
                //{
                //    return;
                //}
                //p.Hide();
                //LoginWindow loginWindow = new LoginWindow();
                //loginWindow.ShowDialog();
                //if (loginWindow.DataContext == null)
                //{
                //    return;
                //}
                //var loginVM = loginWindow.DataContext as LoginViewModel;
                //if (loginVM.isLogin)
                //{
                //    p.Show();
                //}
                //else
                //{
                //    p.Close();
                //}
                p.Show();
            });
            //customercommand = new relaycommand<object>((p) => { return true; }, (p) => { customerwindow wd = new customerwindow(); wd.showdialog(); });
            //suppliercommand = new relaycommand<object>((p) => { return true; }, (p) => { supplierwindow wd = new supplierwindow(); wd.showdialog(); });
            //contractcommand = new relaycommand<object>((p) => { return true; }, (p) => { contractwindow wd = new contractwindow(); wd.showdialog(); });
            //carcommand = new relaycommand<object>((p) => { return true; }, (p) => { CarWindow wd = new CarWindow(); wd.ShowDialog(); });
            //OrderCommand = new RelayCommand<object>((p) => { return true; }, (p) => { OrderWindow wd = new OrderWindow(); wd.ShowDialog(); });
            CarCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CurrentChildView = new ListCarViewModel(); });

        }

        private bool ExecuteShowCarViewCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}