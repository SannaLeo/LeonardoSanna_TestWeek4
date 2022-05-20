using LeonardoSanna_TestWeek4.Core.Entities;
using LeonardoSanna_TestWeek4.Core.InterfaceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositorySpesa spesaRepo;
        private readonly IRepositoryCategoria categoriaRepo;

        public BusinessLayer(IRepositoryCategoria categorie, IRepositorySpesa spese)
        {
            spesaRepo = spese;
            categoriaRepo = categorie;
        }
        public bool AggiungiSpesa(Spesa nuovaSpesa)
        {
            Categoria categoria = categoriaRepo.GetCategoriaById(nuovaSpesa.CategoriaId);
            if (categoria == null)
            {
                Console.WriteLine("Categoria non valida ripsrovare");
                return false;
            }
            else
            {
                return spesaRepo.Add(nuovaSpesa);
            }
        }

        public bool ApprovaSpesa(int Id)
        {
            Spesa spesa = spesaRepo.GetSpesaById(Id);
            if (spesa == null)
            {
                Console.WriteLine("Spesa non trovata");
                return false;
            }
            else
            {
                spesa.Approvato = true;
                spesaRepo.Update(spesa);
                return true;
            }
        }

        public bool EliminaSpesa(int Id)
        {
            Spesa spesa = spesaRepo.GetSpesaById(Id);
            if (spesa == null)
            {
                Console.WriteLine("Spesa non trovata!");
                return false;
            }
            else
            {
                spesaRepo.Delete(spesa);
                return true;
            }
        }

        public List<Spesa> GetAllSpese()
        {
            return spesaRepo.GetAll();
        }

        public List<Spesa> GetAllSpeseApprovate()
        {
            return spesaRepo.GetAll().Where(s => s.Approvato).ToList();
        }

        public List<Spesa> GetAllSpeseByUtente(string utente)
        {
            return spesaRepo.GetAll().Where((s) => s.Utente == utente).ToList();
        }

        public List<Object> GetAllTotaliForEachCategoria()
        {
            //var res = spesaRepo.GetAll().GroupBy(s => s.CategoriaId).Select(a => new { Id = a.Key, Categoria = a., Totale = a.Sum(b => b.Importo) }).ToList();
            var res = new List<Object>();  
            //var res = spesaRepo.GetAll().GroupBy(v => v.Categoria.NomeCategoria, (key, grp) => new{Categoria = key, Totale = grp.Sum(v => v.Importo)});
            foreach (var item in res)
            {
                //Console.WriteLine($"Nome: {item.Categoria} - Totale: {item.Totale}"); 
            }
            return new List<Object>();
        }
    }
}
