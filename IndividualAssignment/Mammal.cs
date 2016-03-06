using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualAssignment
{
    public enum Sex
    {
        Male, Female
    }

    public abstract class Mammal : ILifeform
    {
        [Required]
        public int MammalID { get; set; }

        public static Random rnd = new Random();
        public Reproduction Reproduction { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime Birthdate { get; set; }
        public Sex Sex { get; set; }
        public int Age => GetAge();

        public State State { get; set; }

        protected Mammal()
        {
            Height = 0;
            Weight = 0;

            //Birthdate = DateTime.Now;
            Sex = (Sex)rnd.Next(0, 2);
            State = State.Healthy;
            Reproduction = Reproduction.Sexual;

        }

        public virtual void InitiateDeath()
        {
           State = State.Dead; 
        }

        public int GetAge()
        {
            DateTime now = DateTime.Now;
            int age = now.Year - Birthdate.Year;
            if (now.Month < Birthdate.Month || (now.Month == Birthdate.Month && now.Day < Birthdate.Day)) age--;
            return age;
        }
    }
}