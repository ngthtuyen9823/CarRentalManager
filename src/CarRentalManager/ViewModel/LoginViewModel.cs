using CarRentalManager.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarRentalManager.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public bool isLogin { get; set; }
        private string userName;
        public string UserName { get => userName; set { userName = value; OnPropertyChanged(); } }
        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        public ICommand CloseCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        // mọi thứ xử lý sẽ nằm trong này
        public LoginViewModel()
        {
            isLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { p.Close(); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {
            if (p == null)
                return;
            var accCount = DataProvider.Ins.DB.Users.Where(x => x.email == UserName && x.password == Password).Count();

            if (!(accCount > 0))
            {
                isLogin = true;

                p.Close();
            }
            else
            {
                isLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
        }
    }
}