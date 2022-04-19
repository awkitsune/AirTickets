using AirTickets.Core.DemoClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirTickets.View.Pages
{
	/// <summary>
	/// Логика взаимодействия для AvailableDirectionsPage.xaml
	/// </summary>
	public partial class AvailableDirectionsPage : Page
	{
		public AvailableDirectionsPage()
		{
			InitializeComponent();
		}

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
			var destinations = new ObservableCollection<DestinationItem>();

            if (((ComboBox)sender).SelectedIndex == 0)
            {
				destinations.Add(new DestinationItem()
				{
					Name = "Тестовое направление 1",
					Address = "Майкоп, Россия",
					Description = "Некоторое описание нашего места назначения"
				});
				destinations.Add(new DestinationItem()
				{
					Name = "Тестовое направление 2",
					Address = "Майкоп, Россия",
					Description = "Некоторое описание нашего места назначения"
				});
				destinations.Add(new DestinationItem()
				{
					Name = "Тестовое направление 3",
					Address = "Майкоп, Россия",
					Description = "Некоторое описание нашего места назначения"
				});
				destinations.Add(new DestinationItem()
				{
					Name = "Тестовое направление 4",
					Address = "Майкоп, Россия",
					Description = "Некоторое описание нашего места назначения"
				});
			}

			destinationsGridView.ItemsSource = destinations;
		}

        private void destinationsGridView_ItemClick(object sender, ModernWpf.Controls.ItemClickEventArgs e)
        {

        }
    }
}
