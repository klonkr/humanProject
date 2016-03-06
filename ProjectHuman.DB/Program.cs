using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHuman.DB.Domain;

namespace ProjectHuman.DB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProjectHumanContext context = new ProjectHumanContext())
            {
                //context.Humans.Add(new Human() {FirstName = "Anton"});
                //context.Pets.Add(new Pet() {Name = "dogge", PetType =  new PetType() {Type = "Dog"}});

                Human test = context.Humans.Where(u => u.FirstName == "Anne").First();
                Human anton = context.Humans.First(u => u.FirstName == "Anton");

                anton.MotherId = test.Id;


                //Human anton = context.Humans.First(u => u.FirstName == "Anton");
                //Human cr = context.Humans.First(u => u.FirstName == "Christopher-Robin");
                //anton.Children.Add(cr);

                context.SaveChanges();
            }
        }
    }
}
