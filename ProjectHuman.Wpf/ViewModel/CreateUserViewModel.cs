using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProjectHuman.DB.Domain;
using ProjectHuman.Lib.BusinessLogic;
using ProjectHuman.Wpf.Annotations;

namespace ProjectHuman.Wpf.ViewModel
{
    class CreateUserViewModel : INotifyPropertyChanged
    {
        private HumanLogic HumanLogic = new HumanLogic(new Repository());
        public List<Human> Humans { get; private set; }
        public Human Human { get; set; }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateTime { get; set; }

        public CreateUserViewModel()
        {
            using (ProjectHumanContext context = new ProjectHumanContext())
            {
                Humans = context.Humans.ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateNameProps(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void CreateHuman()
        {
            HumanLogic.CreateHuman(FirstName, LastName, DateTime);
        }

        public void UpdateDobProp(DateTime displayDate)
        {
            DateTime = displayDate;
        }
    }
}