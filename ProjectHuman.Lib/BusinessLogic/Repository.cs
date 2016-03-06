using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using ProjectHuman.DB.Domain;

namespace ProjectHuman.Lib.BusinessLogic
{
    public class Repository : IRepository
    {
        public Logger Logger { get; set; }

        public Repository()
        {
            Logger = new Logger();
        }
        public bool Create<T>(T t) where T : class
        {
            try
            {
                using (ProjectHumanContext context = new ProjectHumanContext())
                {
                    context.Set<T>().Add(t);
                    context.SaveChanges();
                }
                Logger.DatabaseAction($"MM: {t} successfully written to database.");
                return true;
            }
            catch (Exception)
            {
                Logger.DatabaseAction($"EE: {t} failed to be written to database.");
                return false;
            }
            
        }

        public List<T> Read<T>() where T : class
        {
            try
            {
                List<T> output = new List<T>();
                using (ProjectHumanContext context = new ProjectHumanContext())
                {
                    output = context.Set<T>().ToList();
                }
                Logger.DatabaseAction($"MM: successfully returned list of {typeof(T)} from database.");
                return output;
            }
            catch (Exception)
            {
                Logger.DatabaseAction($"EE: failed to return list of {typeof(T)} from database.");
                return null;
            }
        }

        public bool Update(Human human)
        {
            try
            {
                using (ProjectHumanContext context = new ProjectHumanContext())
                {
                    context.Entry(human).State = EntityState.Modified;
                    context.SaveChanges();
                }
                Logger.DatabaseAction($"MM: {human} successfully updated in database.");
                return true;
            }
            catch (Exception ex)
            {
                Logger.DatabaseAction($"EE: {human} failed to be updated in database. {ex.Message}");
                return false;
            }
        }
    }
}
