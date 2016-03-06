using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHuman.DB.Domain
{

    public class Human : Mammal
    {
        [NotMapped]
        private string _firstName;

        [Column("First name", TypeName = "nvarchar")]
        public string FirstName
        {
            get { return _firstName;}
            set { _firstName = value; }
        }

        [NotMapped]
        private string _lastName;

        [Column("Last name", TypeName = "nvarchar")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Pnr { get; set; }

        public Guid? MotherId { get; set; }
        public Guid? FatherId { get; set; }

        //public List<Human> Parents { get; set; }

        public virtual ICollection<Human> Children { get; set; }
        public virtual ICollection<Human> Friends { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }

        public Human()
        {
            Friends = new List<Human>();
            Pets = new List<Pet>();
            Children = new List<Human>();
        }

        public Human(DateTime birthdate)
        {
            Friends = new List<Human>();
            Pets = new List<Pet>();
            Children = new List<Human>();
            Birthdate = birthdate;
            Pnr = GeneratePersonNumber(Birthdate);
        }

        //private string CheckNameContainsCorrectCharactersElseNull(string nameToCheck)
        //{
        //    string compare = nameToCheck.ToLower();
        //    if (!(from character in compare
        //          let validCharacters = "abcdefghijklmonpqrstuvwxyzåäö"
        //          where !validCharacters.Contains(character)
        //          select character).Any()) return nameToCheck;
        //    Console.WriteLine("error.");
        //    return null;
        //}

        private string GeneratePersonNumber(DateTime todaysDateAndTime)
        {
            string generatedPersonNumber = null;

            generatedPersonNumber += todaysDateAndTime.Year;
            generatedPersonNumber += todaysDateAndTime.Month.ToString("d2");
            generatedPersonNumber += todaysDateAndTime.Day.ToString("d2");

            generatedPersonNumber += rnd.Next(0, 9999);

            return generatedPersonNumber;
        }

    }
}