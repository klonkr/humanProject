using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    interface IPet
    {
        string Name { get; set; }
        Human Owner { get; set; }

        //void Feed();
        //void TakeToTheFarm();
        
    }
}
