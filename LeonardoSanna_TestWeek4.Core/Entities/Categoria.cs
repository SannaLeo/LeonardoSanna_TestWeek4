using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeonardoSanna_TestWeek4.Core.Entities
{
    [Table("Categorie")]
    public class Categoria
    {
        [Key]
        public int Id{ get; set; }

        [Column("Categoria")]
        public string NomeCategoria{ get; set; }

        public ICollection<Spesa> Spese { get; set; }

        public override string ToString()
        {
            return $"{NomeCategoria}";
        }
    }
}