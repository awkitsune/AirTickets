using AirTickets.Core.GridViewTemplates;
using ModernWpf.Controls;
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
	public partial class AvailableDirectionsPage : System.Windows.Controls.Page
    {
		public AvailableDirectionsPage()
		{
			InitializeComponent();

			countryComboBox.SelectedIndex = 0;
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
					Description = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Massa placerat duis ultricies lacus. Nam at lectus urna duis convallis convallis tellus id interdum. Ac tincidunt vitae semper quis lectus nulla at volutpat. Interdum consectetur libero id faucibus nisl tincidunt eget nullam non. "
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

        private void destinationsGridView_ItemClick1(object sender, ModernWpf.Controls.ItemClickEventArgs e)
        {

        }

        private void destinationsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
			var card = (DestinationItem)e.ClickedItem;
			var destWnd = new DestinationSelectionWindow(card);
			destWnd.Owner = Window.GetWindow(this);
			destWnd.ShowDialog();
		}
    }
}
