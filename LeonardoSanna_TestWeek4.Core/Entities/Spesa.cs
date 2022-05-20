using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.Core.Entities
{
    [Table("Spese")]
    public class Spesa
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Descrizione { get; set; }
        public string Utente{ get; set; }
        public decimal Importo{ get; set; }
        public bool Approvato { get; set; }

        public override string ToString()
        {
            return $"Id:{Id} - Data: {Data.ToShortDateString()} Categoria: {Categoria.ToString()} Descrizione: {Descrizione} - Utente: {Utente} - Importo: {Importo} - Approvato: {(Approvato ? "Si" : "No")}";
        }
    }
}
