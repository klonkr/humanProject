using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    public class Dog : Mammal, IPet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Human Owner { get; set; }

        //public void Feed()
        //{
            
        //}

        //public void TakeToTheFarm()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
