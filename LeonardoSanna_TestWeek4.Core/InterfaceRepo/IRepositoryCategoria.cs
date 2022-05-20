using LeonardoSanna_TestWeek4.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.Core.InterfaceRepo
{
    public interface IRepositoryCategoria : IRepository<Categoria>
    {
        Categoria GetCategoriaById(int id);
    }
}
