using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectHuman.DB.Domain;

namespace ProjectHuman.Lib.BusinessLogic
{
    public interface IRepository
    {
        bool Create<T>(T t) where T : class;
        List<T> Read<T>() where T : class;
        bool Update(Human human);
    }
}
