using LeonardoSanna_TestWeek4.Core.Entities;
using LeonardoSanna_TestWeek4.Core.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.RepositoryADOEF
{
    public class RepositorySpeseEF : IRepositorySpesa
    {
        public bool Add(Spesa item)
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
                Console.WriteLine(ex.InnerException);
                
                return false;
            }
        }

        public bool Delete(Spesa item)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Spese.Remove(item);
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

        public List<Spesa> GetAll()
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    return ctx.Spese.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Spesa>();
            }
        }

        public Spesa GetSpesaById(int id)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    return ctx.Spese.Find(id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Spesa();
            }
        }

        public bool Update(Spesa item)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    ctx.Spese.Update(item);
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
