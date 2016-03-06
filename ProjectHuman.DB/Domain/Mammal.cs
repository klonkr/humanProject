using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHuman.DB.Domain
{
    public enum Sex
    {
        Male, Female
    }

    public abstract class Mammal : ILifeform
    {

        [Key]
        public Guid Id { get; set; }

        [NotMapped]
        public static Random rnd = new Random();
        public Reproduction Reproduction { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime Birthdate { get; set; }
        public Sex Sex { get; set; }

        [NotMapped]
        public int Age => GetAge();

        public State State { get; set; }

        protected Mammal()
        {
            Id = Guid.NewGuid();
            Height = 0;
            Weight = 0;
            //Sex = (Sex)rnd.Next(0, 2);
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