using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    public enum State
    {
        Dead, Braindead, Comatose, Sick, Healthy
    }
    public enum Reproduction
    {
        Asexual, Sexual
    }
    public interface ILifeform
    {
        Reproduction Reproduction { get; set; } 
        double Height { get; set; }
        double Weight { get; set; }
        int Age { get; }


        DateTime Birthdate { get; set; }
        State State { get; set; }

        void InitiateDeath();
        int GetAge();
    }
}
