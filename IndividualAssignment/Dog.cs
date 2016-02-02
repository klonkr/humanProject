using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    class Dog : Mammal, IPet
    {
        public string Name { get; set; }
        public Human Owner { get; set; }

        public void Feed()
        {
            
        }

        public void TakeToTheFarm()
        {
            throw new NotImplementedException();
        }
    }
}
