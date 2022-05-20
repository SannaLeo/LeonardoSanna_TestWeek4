using LeonardoSanna_TestWeek4.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Spesa> GetAllSpese();
        List<Spesa> GetAllSpeseApprovate();
        List<Spesa> GetAllSpeseByUtente(string utente);
        List<Object> GetAllTotaliForEachCategoria();
        Categoria GetCategoriaById(int id);
        bool AggiungiSpesa(Spesa nuovaSpesa);
        bool AggiungiCategoria(Categoria nuovaSpesa);
        bool ApprovaSpesa(int Id);
        bool EliminaSpesa(int Id);
        
    }
}
