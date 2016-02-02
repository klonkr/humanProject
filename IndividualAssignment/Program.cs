using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IndividualAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Human adam = new Human() {FirstName = "Adam", Sex = Sex.Male, Birthdate = DateTime.Now.AddYears(-22)};
            Human eva = new Human() {FirstName = "!ve", Sex = Sex.Female, Birthdate = DateTime.Now.AddYears(-19)};

            Human henrik = new Human() {FirstName = "henrik", Father = adam, Mother = eva, Sex = Sex.Male };
            Human elsa = new Human() { FirstName = "elsa", Father = adam, Mother = eva, Sex = Sex.Female };
            adam.Children.Add(henrik);
            adam.Children.Add(elsa);
            eva.Children.Add(henrik);
            eva.Children.Add(elsa);

            Human erik = new Human() { FirstName = "erik", Father = henrik, Mother = elsa, Sex = Sex.Male, Birthdate = DateTime.Now.AddYears(-26) };
            Human anna = new Human() { FirstName = "anna", Father = henrik, Mother = elsa, Sex = Sex.Female };
            henrik.Children.Add(erik);
            henrik.Children.Add(anna);
            elsa.Children.Add(erik);
            elsa.Children.Add(anna);

            Human isak = new Human() { FirstName = "isak", Sex = Sex.Male, Birthdate = DateTime.Now.AddYears(-22) };
            Human maria = new Human() { FirstName = "maria", Sex = Sex.Female, Birthdate = DateTime.Now.AddYears(-19) };

            Human dennis = new Human() { FirstName = "dennis", Father = isak, Mother = maria, Sex = Sex.Male };
            Human klas = new Human() { FirstName = "klas", Father = isak, Mother = maria, Sex = Sex.Male };
            Human hanna = new Human() { FirstName = "hanna", Father = isak, Mother = maria, Sex = Sex.Female };
            isak.Children.Add(dennis);
            isak.Children.Add(klas);
            isak.Children.Add(hanna);
            maria.Children.Add(dennis);
            maria.Children.Add(klas);
            maria.Children.Add(hanna);

            Human sven = new Human() { FirstName = "sven", Father = klas, Mother = hanna, Sex = Sex.Male, Birthdate = DateTime.Now.AddYears(-26)};
            Human tove = new Human() { FirstName = "tove", Father = klas, Mother = hanna, Sex = Sex.Female, Birthdate = DateTime.Now.AddYears(-26) };
            klas.Children.Add(sven);
            klas.Children.Add(tove);
            hanna.Children.Add(sven);
            hanna.Children.Add(tove);

            sven.FirstName = "test";

            sven.MarryAnotherAdult(erik);


            bool test = tove.CheckIfRelatives(sven);

            foreach (var child in klas.Children)
            {
                Console.WriteLine($"{child.FirstName} {child.LastName}");
            }
        }
    }
}
