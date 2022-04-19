using AirTickets.View.Pages;
using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void NavigationView_Loaded(object sender, RoutedEventArgs e)
		{
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "main")
                {
                    NavView.SelectedItem = item;
                    NavView_Navigate((NavigationViewItem)item);
                    break;
                }
            }
        }

		private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			if (args.IsSettingsInvoked)
			{

			}
			else
			{
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate((NavigationViewItem)item);
			}
		}
        private void NavView_Navigate(NavigationViewItem item)
		{
            NavView.Header = item.Content;

            switch (item.Tag)
			{
                case "account":
                    ContentFrame.Navigate(typeof(AccountPage));
                    break;
                case "main":
                    ContentFrame.Navigate(typeof(MainPage));
                    break;
                case "available_directions":
                    ContentFrame.Navigate(typeof(AvailableDirectionsPage));
                    break;
                case "family":
                    ContentFrame.Navigate(typeof(FamilyPage));
                    break;
                case "my_tickets":
                    ContentFrame.Navigate(typeof(TicketsPage));
                    break;
                case "about":
                    ContentFrame.Navigate(typeof(AboutPage));
                    break;
                default:
					break;
			}
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{

		}
	}
}
