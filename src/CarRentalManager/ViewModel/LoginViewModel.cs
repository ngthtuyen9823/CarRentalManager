using CarRentalManager.dao;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using System;
using CarRentalManager.state;
using CarRentalManager.enums;
using System.Diagnostics.Eventing.Reader;

namespace CarRentalManager.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        private string supplierId { get; set; }
        public bool isLogin { get; set; }
        private string email;
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        readonly UserDAO userDAO = new UserDAO();
        readonly SupplierDAO supplierDAO = new SupplierDAO();  
        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

        public LoginViewModel()
        {
            isLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        private bool comparePassword(string currentPassword, string oldPassword)
        {
            return currentPassword == oldPassword;
        }
        private void closeLoginWindowAndOpenDashboard(Window p)
        {
            Application.Current.Windows[0].Close();
            var mainWindow = new DashBoard();
            mainWindow.Show();
            p.Close();
        }
        private void closeLoginWindowAndOpenSubDashboard(Window p)
        {
            Application.Current.Windows[0].Close();
            var mainWindow = new SupplierDashBoard();
            mainWindow.Show();
            p.Close();
        }
        void Login(Window p)
        {
            if (p == null)
                return;
            User currentUser = userDAO.getInforByEmail(Email);
            Supplier currentSupplier = supplierDAO.getInforByEmail(Email);
            if (currentUser == null && currentSupplier == null)
            {
                MessageBox.Show("Your account is not exist, please sign up!");
            } 
            else
            {
                if (comparePassword(Password, currentUser?.Password?.Trim()))
                {
                    LoginInInforState.setState(currentUser.ID, currentUser.Name, currentUser.Role);
                    closeLoginWindowAndOpenDashboard(p);
                }
                else if (comparePassword(Password, currentSupplier?.Password?.Trim()))
                {
                    LoginInInforState.setState(currentSupplier.ID, currentSupplier.Name, EUserRole.SUPPLIER);
                    closeLoginWindowAndOpenSubDashboard(p);
                }
                else
                {
                    MessageBox.Show("Password is invalid!");
                }
            }
        }
    }
}