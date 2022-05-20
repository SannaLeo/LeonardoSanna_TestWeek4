
using LeonardoSanna_TestWeek4.Core.Entities;
using LeonardoSanna_TestWeek4.RepositoryADOEF.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LeonardoSanna_TestWeek4.RepositoryADOEF
{
    internal class MasterContext : DbContext
    {
        public DbSet<Spesa> Spese { get; set; }
        public DbSet<Categoria> Categorie { get; set; }

        public MasterContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Spesa>(new SpesaConfiguration());
            modelBuilder.ApplyConfiguration<Categoria>(new CategoriaConfiguration());
        }
    }
}