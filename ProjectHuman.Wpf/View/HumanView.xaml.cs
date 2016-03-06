using System.Windows;
using ProjectHuman.DB.Domain;
using ProjectHuman.Wpf.ViewModel;

namespace ProjectHuman.Wpf.View
{
    /// <summary>
    /// Interaction logic for HumanView.xaml
    /// </summary>
    public partial class HumanView : Window
    {
        public HumansViewModel HumansViewModel => DataContext as HumansViewModel;
        public HumanView(Human human)
        {
            InitializeComponent();
            DataContext = new HumansViewModel();
            HumansViewModel.UpdateHumanProp(human);
        }

        private void UpdateUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            HumansViewModel.UpdateHuman(FirstNameBox.Text, LastNameBox.Text);
        }
    }
}
