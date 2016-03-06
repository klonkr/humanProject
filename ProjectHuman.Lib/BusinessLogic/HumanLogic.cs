using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHuman.DB.Domain;

namespace ProjectHuman.Lib.BusinessLogic
{
    public class HumanLogic
    {
        Random rnd = new Random();
        private IRepository Repo { get; set; }

        public HumanLogic(IRepository repo)
        {
            Repo = repo;
        }

        public bool CreateHuman(string firstName, string lastName, DateTime pickedDateOfBirth)
        {
            Human human = new Human()
            {
                FirstName = CheckNameContainsCorrectCharactersElseNull(firstName),
                LastName = CheckNameContainsCorrectCharactersElseNull(lastName),
                Birthdate = new DateTime(pickedDateOfBirth.Year, pickedDateOfBirth.Month, pickedDateOfBirth.Day),
                Pnr = GeneratePersonNumber(pickedDateOfBirth)
            };

            if (human.FirstName != null && human.LastName != null)
            {
                Repo.Create(human);
                return true;
            }
            return false;
        }

        public List<Human> GetAllHumans()
        {
            return Repo.Read<Human>();
        }

        public string GeneratePersonNumber(DateTime todaysDateAndTime)
        {
            string generatedPersonNumber = null;

            generatedPersonNumber += todaysDateAndTime.ToString("yyMMdd");

            generatedPersonNumber += rnd.Next(0, 9999);

            return generatedPersonNumber;
        }

        public string CheckNameContainsCorrectCharactersElseNull(string nameToCheck)
        {
            string compare = nameToCheck.ToLower();
            if (!(from character in compare
                  let validCharacters = "abcdefghijklmonpqrstuvwxyzåäö"
                  where !validCharacters.Contains(character)
                  select character).Any()) return nameToCheck;
            Console.WriteLine("error.");
            return null;
        }

        public bool UpdateHuman(Human human)
        {
            if (Repo.Update(human))
                return true;
            return false;

        }
    }
}
