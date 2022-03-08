using AirTickets.Core.Encrypt;
using AirTickets.Core.Validate;
using AirTickets.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace AirTickets.ViewModel
{
    internal class RegistrationWindowViewModel : BaseViewModel
    {
        private RegistrationWindow? window = null;

        private string _login = "";
        private string _password = "";
        private string _passwordRep = "";
        private bool _isLoading = false;

        private bool _isEmailValid = true;

        public ICommand LoginClick
        {
            get;
        }
        public ICommand BackClick
        {
            get;
        }

        public RegistrationWindowViewModel()
        {
            LoginClick = new DelegateCommand(RegisterUser);
            BackClick = new DelegateCommand(GoBack);

            foreach (var _window in Application.Current.Windows)
            {
                if (_window as Window is RegistrationWindow)
                {
                    window = _window as RegistrationWindow;
                }
            }
        }

        #region Commands
        private void GoBack(object obj)
        {
            window?.Close();
        }
        private async void RegisterUser(object obj)
        {
            string pass = _password;
            string passRep = _passwordRep;
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
                _isEmailValid = Validate.Email(Login);
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
        public string PasswordRep
        {
            private get => _passwordRep;
            set
            {
                _passwordRep = value;
                OnPropertyChanged(nameof(PasswordRep));
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
