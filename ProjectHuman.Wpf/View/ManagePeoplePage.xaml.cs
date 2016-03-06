using System.Windows.Controls;
using System.Windows.Input;
using ProjectHuman.DB.Domain;
using ProjectHuman.Wpf.ViewModel;

namespace ProjectHuman.Wpf.View
{
    /// <summary>
    /// Interaction logic for ManagePeoplePage.xaml
    /// </summary>
    public partial class ManagePeoplePage : Page 
    {
        public HumansViewModel HumansViewModel => DataContext as HumansViewModel;
        public ManagePeoplePage()
        {
            InitializeComponent();
            DataContext = new HumansViewModel();
        }

        private void UserListView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Human human = UserListView.SelectedItem as Human;
            HumanView hw = new HumanView(human);
            hw.Show();
        }

        private void UserListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Human human = UserListView.SelectedItem as Human;
            HumansViewModel.UpdateHumanProp(human);
        }
    }
}
