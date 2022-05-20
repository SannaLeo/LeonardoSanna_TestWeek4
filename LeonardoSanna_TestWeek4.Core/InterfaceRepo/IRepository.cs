using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.Core.InterfaceRepo
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);

    }
}
