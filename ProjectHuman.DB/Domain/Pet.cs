using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHuman.DB.Domain
{
    public class Pet : Mammal
    {
        public string Name { get; set; }
        public virtual Human Owner { get; set; }

        public PetType PetType { get; set; }

        //void Feed();
        //void TakeToTheFarm();
        
    }
}
