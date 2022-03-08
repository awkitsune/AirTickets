using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using AirTickets.Core.Encrypt;
using AirTickets.Core.Validate;
using AirTickets.View;

namespace AirTickets.ViewModel
{
    internal class AuthenticationWindowViewModel : BaseViewModel
    {
        private AuthenticationWindow? window = null;

        private string _login = "";
        private string _password = "";
        private bool _isLoading = false;
        private Visibility _windowVisibility = Visibility.Visible;

        private bool _isEmailValid = true;

        public ICommand LoginClick
        {
            get;
        }
        public ICommand RegisterClick
        {
            get;
        }

        public AuthenticationWindowViewModel()
        {
            LoginClick = new DelegateCommand(AuthenticateUser);
            RegisterClick = new DelegateCommand(RegisterUser);

            foreach (var _window in Application.Current.Windows)
            {
                if (_window as Window is AuthenticationWindow)
                {
                    window = _window as AuthenticationWindow;
                }
            }
        }

        #region Commands
        private void RegisterUser(object obj)
        {
            window?.Hide();

            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.ShowDialog();

            window?.Show();

        }
        private async void AuthenticateUser(object obj)
        {
            string pass = _password;
            IsLoading = Visibility.Visible;

            if (string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(Login))
            {
                ThemedMessageBox.Show("Логин или пароль не должны быть пустыми", "Ошибка данных");
            }
            else
            {
                if (!Validate.Email(_login))
                {
                    ThemedMessageBox.Show("Неверный адрес электронной почты", "Ошибка данных");
                }
                else
                {
                    //get data from api

                    if (true /* there is responce check */)
                    {
                        if (Encrypt.VerifyPassword(pass, "hash", "b3J0am5ob2lkZmhub2Rmbmht"))
                        {

                        }
                        else
                        {
                            ThemedMessageBox.Show("Неправильный логин или пароль");
                        }
                    }
                    else
                    {
                        ThemedMessageBox.Show("Сервер сейчас недоступен, попробойте позже", "200");
                    }
                }
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
                _isEmailValid = Validate.Email(_login);
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
        public Visibility WindowVisibility
        {
            get => _windowVisibility;
            set
            {
                _windowVisibility = value;
                OnPropertyChanged(nameof(WindowVisibility));
            }
        }
        public bool IsLoginEnabled => !_isLoading;
        public Visibility EmailWrongMessageVisibility => _isEmailValid ? Visibility.Collapsed : Visibility.Visible;

        #endregion
    }
}
