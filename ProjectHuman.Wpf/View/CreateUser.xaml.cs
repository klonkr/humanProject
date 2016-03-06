using System;
using System.Windows;
using System.Windows.Controls;
using ProjectHuman.DB.Domain;
using ProjectHuman.Lib.BusinessLogic;
using ProjectHuman.Wpf.ViewModel;

namespace ProjectHuman.Wpf.View
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {
        CreateUserViewModel ViewModel => DataContext as CreateUserViewModel;
        public CreateUser()
        {
            InitializeComponent();
            DataContext = new CreateUserViewModel();

        }

        private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.CreateHuman();
        }

        private void FirstOrLastNameTxtB_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.UpdateNameProps(FirstNameTxtB.Text, LastNameTxtB.Text);

        }

        private void PickedDateOfBirth_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.UpdateDobProp(PickedDateOfBirth.DisplayDate);
        }
    }
}
