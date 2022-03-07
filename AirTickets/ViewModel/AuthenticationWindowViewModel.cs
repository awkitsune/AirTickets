using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace AirTickets.ViewModel
{
    internal class AuthenticationWindowViewModel : BaseViewModel
    {
        private string _login = "";
        private string _password = "";
        private bool _isLoading = false;

        public ICommand LoginClick
        {
            get;
            private set;
        }

        public AuthenticationWindowViewModel()
        {
            LoginClick = new DelegateCommand(AuthenticateUser);
        }

        #region Commands
        private void AuthenticateUser(object obj)
        {
            IsLoading = Visibility.Visible;
        }
        #endregion

        #region Properties
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            private get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public Visibility IsLoading
        {
            get
            {
                return _isLoading ? Visibility.Visible : Visibility.Hidden;
            }
            set
            {
                _isLoading = value == Visibility.Visible ? true : false;
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }
        public bool IsLoginEnabled
        {
            get { return !_isLoading; }
        }
        #endregion
    }
}
