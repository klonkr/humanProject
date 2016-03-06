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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectHuman.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileNewPerson_OnClick(object sender, RoutedEventArgs e)
        {
            MainPage.NavigationService.Navigate(new View.CreateUser());
        }

        private void PeopleManagementItem_OnClick(object sender, RoutedEventArgs e)
        {
            MainPage.NavigationService.Navigate(new View.ManagePeoplePage());
        }
    }
}
