using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using AirTickets.Core.Encrypt;

namespace AirTickets.ViewModel
{
    internal class AuthenticationWindowViewModel : BaseViewModel
    {
        private string _login = "";
        private string _password = "";
        private bool _isLoading = false;

        private bool _isEmailValid = true;

        public ICommand LoginClick
        {
            get;
        }

        public AuthenticationWindowViewModel()
        {
            LoginClick = new DelegateCommand(AuthenticateUser);
        }

        #region Commands
        private async void AuthenticateUser(object obj)
        {
            string pass = _password;
            Password = "";
            IsLoading = Visibility.Visible;

            //get data from db

            if (true /* there is responce check */)
            {
                if (Encrypt.VerifyPassword(pass, "hash", "b3J0am5ob2lkZmhub2Rmbmht"))
                {

                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Сервер сейчас недоступен, попробойте позже", "200", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            IsLoading = Visibility.Collapsed;
        }
        #endregion

        #region Properties
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                _isEmailValid = Regex.IsMatch(
                    Login,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase
                    );
                OnPropertyChanged(nameof(EmailWrongMessageVisibility));
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            private get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public Visibility IsLoading
        {
            get => _isLoading ? Visibility.Visible : Visibility.Hidden;
            set
            {
                _isLoading = value == Visibility.Visible ? true : false;
                OnPropertyChanged(nameof(IsLoading));
                OnPropertyChanged(nameof(IsLoginEnabled));
            }
        }
        public bool IsLoginEnabled => !_isLoading;
        public Visibility EmailWrongMessageVisibility => _isEmailValid ? Visibility.Collapsed : Visibility.Visible;

        #endregion
    }
}
