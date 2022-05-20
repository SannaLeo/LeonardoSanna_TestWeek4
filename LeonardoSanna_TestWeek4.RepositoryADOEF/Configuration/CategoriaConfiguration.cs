using LeonardoSanna_TestWeek4.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.RepositoryADOEF.Configuration
{
    internal class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id).HasName("PK_Categoria");
            builder.Property(c => c.NomeCategoria).IsRequired(true);

            builder.HasMany(c => c.Spese).WithOne(s => s.Categoria).HasConstraintName("FK_Categoria");
        }
    }
}
