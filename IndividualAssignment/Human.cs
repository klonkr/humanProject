using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace IndividualAssignment
{
    public class Human : Mammal
    {
        private Human _partner;
        private string _firstName;
        private string _lastName;

        #region Properties
        public static int NumberOfPeopleAlive { get; set; }

        public string FirstName
        {
            get {return _firstName;}
            set { _firstName = CheckNameContainsCorrectCharactersElseNull(value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = CheckNameContainsCorrectCharactersElseNull(value); }
        }
        public string PersonNumber { get; }
        public Human Mother { get; set; }
        public Human Father { get; set; }
        public List<Human> Parents { get; set; } 
        public new List<Human> Children { get; set; }

        public Human Partner
        {
            get { return _partner; }
            set { MarryAnotherAdult(value); }
        }

        public List<Human> Friends { get; set; }
        #endregion

        #region Constructors

        public Human()
        {
            Children = new List<Human>();
        } // Adam and Eve
        public Human(Human mother, Human father)
        {
            NumberOfPeopleAlive += 1;
            PersonNumber = GeneratePersonNumber(Birthdate);
            Friends = new List<Human>();
            Father = father;
            Mother = mother;
            Children = new List<Human>();
        }

        private string CheckNameContainsCorrectCharactersElseNull(string nameToCheck)
        {
            string compare = nameToCheck.ToLower();
            if ((from character in compare let validCharacters = "abcdefghijklmonpqrstuvwxyzåäö" where !validCharacters.Contains(character) select character).Any())
            {
                Console.WriteLine("error.");
                return null;
            }
            return nameToCheck;
        }

        protected Human(string firstName, string lastName, Human mother, Human father) : this(mother, father)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion

        public Human MakeBabyWithAnotherAdult(Human partner)
        {
            Human baby = null;
            if (this.Sex != partner.Sex)
            {
                baby = this.Sex == Sex.Female ? new Human(this, partner) : new Human(partner, this);
            }
            Children.Add(baby);
            partner.Children.Add(baby);

            return baby;
        }

        public bool MarryAnotherAdult(Human partner)
        {
            if (this.Age > 18 && partner.Age > 18)
            {
                if (CheckIfConsious() && partner.CheckIfConsious())
                {
                    if (Partner == null && partner.Partner == null)
                    {
                        if (this != partner)
                        {
                            if (CheckIfRelatives(partner))
                            {
                                _partner = partner;
                                partner._partner = this;
                                return true;
                            }
                            Console.WriteLine("Too related!!!");
                        }
                        else
                            Console.WriteLine($"{FirstName} can't marry themselves.");
                    }
                    else
                        Console.WriteLine(
                            $"Both parties ({FirstName} and {partner.FirstName}) must not be married no someone else.");
                }
                else
                    Console.WriteLine(
                        $"Both parties ({FirstName} and {partner.FirstName}) must both be consious.");
            }
            else
                Console.WriteLine(
                    $"Both parties ({FirstName} and {partner.FirstName}) must both be over 18.");

            return false;
        }

        public void DivorceAnotherAdult()
        {
            Partner.Partner = null;
            Partner = null;
        }

        public override void InitiateDeath()
        {
            if (Partner != null)
                DivorceAnotherAdult();
            State = State.Dead;
            NumberOfPeopleAlive -= 1;
        }

        public bool CheckIfRelatives(Human partner)
        {
            Human mother = Mother;
            Human father = Father;

            while (partner != father)
            {
                if (father.Children.Any(child => partner == child))
                    return false;
                if (father.Father == null)
                    return true;

                father = father.Father;

                while (partner != mother)
                {
                    if (mother.Children.Any(child => partner == child))
                        return false;
                    if (mother.Father == null)
                        return true;

                    mother = mother.Mother;
                }
            }
            return false;
        }

        public bool CheckIfRelatives2(Human partner)
        {
            Human mother = Mother;
            Human father = Father;

            while (partner != father)
            {
                if (father.Children.Any(child => partner == child))
                    return false;
                if (father.Father == null)
                    return true;

                father = father.Father;

                while (partner != mother)
                {
                    if (mother.Children.Any(child => partner == child))
                        return false;
                    if (mother.Father == null)
                        return true;

                    mother = mother.Mother;
                }
            }
            return false;
        }

        //public bool CheckIfFamilyTiesAreOkForMarriage(Human partner)
        //{
        //    if (!(this.Mother == Partner.Mother && this.Father == partner.Father))
        //    {
        //        if (!(this.Mother == partner || this.Father == partner))
        //            return true;
        //    }
        //    return false;
        //}

        public bool CheckIfConsious()
        {
            return State > State.Comatose;
        }

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