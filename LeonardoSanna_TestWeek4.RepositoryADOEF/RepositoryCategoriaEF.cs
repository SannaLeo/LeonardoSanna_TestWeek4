using LeonardoSanna_TestWeek4.Core.Entities;
using LeonardoSanna_TestWeek4.Core.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.RepositoryADOEF
{
    public class RepositoryCategoriaEF : IRepositoryCategoria
    {
        public bool Add(Categoria item)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Add(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Categoria item)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Categorie.Remove(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Categoria> GetAll()
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    return ctx.Categorie.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Categoria>();
            }
        }

        public Categoria GetCategoriaById(int id)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    return ctx.Categorie.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Categoria();
            }
        }

        public bool Update(Categoria item)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Categorie.Update(item);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
