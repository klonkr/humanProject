using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ProjectHuman.DB.Domain;
using ProjectHuman.Lib.BusinessLogic;
using ProjectHuman.Wpf.Annotations;

namespace ProjectHuman.Wpf.ViewModel
{
    class MainViewModel
    {
        public ICollectionView Humans { get; private set; }
        public HumanLogic HumanLogic = new HumanLogic(new Repository());

        public MainViewModel()
        {
            Humans = new ListCollectionView(HumanLogic.GetAllHumans());
        }

        private void SelectedItemChanged(object sender, EventArgs e)
        {
            Human current = Humans.CurrentItem as Human;
        }
    }
}
