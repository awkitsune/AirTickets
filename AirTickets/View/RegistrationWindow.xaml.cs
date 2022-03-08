using AirTickets.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirTickets.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void passBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((RegistrationWindowViewModel)DataContext).Password = passBox.Password;
        }

        private void passRepBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ((RegistrationWindowViewModel)DataContext).PasswordRep = passRepBox.Password;
        }
    }
}
