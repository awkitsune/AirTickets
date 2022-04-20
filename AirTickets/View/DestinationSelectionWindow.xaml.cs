using AirTickets.Core.GridViewTemplates;
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
using System.Windows.Shapes;

namespace AirTickets.View
{
    /// <summary>
    /// Логика взаимодействия для DestinationSelectionWindow.xaml
    /// </summary>
    public partial class DestinationSelectionWindow : Window
    {
        public DestinationSelectionWindow(DestinationItem destinationItem)
        {
            InitializeComponent();

            mainItemsControl.ItemsSource = new ObservableCollection<DestinationItem>() { destinationItem };
        }
    }
}
