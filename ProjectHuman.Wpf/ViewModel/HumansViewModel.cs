using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using ProjectHuman.DB.Domain;
using ProjectHuman.Lib.BusinessLogic;
using ProjectHuman.Wpf.Annotations;

namespace ProjectHuman.Wpf.ViewModel
{
    public class HumansViewModel
    {
        private HumanLogic humanLogic = new HumanLogic(new Repository());
        public List<Human> Humans { get; private set; }
        public Human Human { get; set; }
        public HumansViewModel()
        {
            Humans = humanLogic.GetAllHumans();
        }

        public HumansViewModel(Human human)
        {
            Humans = humanLogic.GetAllHumans();
            Human = human;
        }

        public void UpdateHumanProp(Human human)
        {
            Human = human;
        }

        public void UpdateHuman(string firstName, string lastName)
        {
            Human.FirstName = firstName;
            Human.LastName = lastName;
            humanLogic.UpdateHuman(Human);
        }
    }
}
