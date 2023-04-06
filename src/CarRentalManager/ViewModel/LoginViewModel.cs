using CarRentalManager.dao;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CarRentalManager.modals;
using System;

namespace CarRentalManager.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public bool isLogin { get; set; }
        private string email;
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        readonly UserDAO userDAO = new UserDAO();
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
        void Login(Window p)
        {
            if (p == null)
                return;
            User currentUser = userDAO.getUserWithEmail(Email);
            if(currentUser == null)
            {
                MessageBox.Show("Tài khoản không tồn tại, xin vui lòng đăng ký");
            } 
            else
            {
                if (comparePassword(Password, currentUser.Password.Trim()))
                {
                    Application.Current.Windows[0].Close();

                    var mainWindow = new DashBoard();
                    mainWindow.Show();
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Sai mật khẩu!");
                }
            }
        }
    }
}