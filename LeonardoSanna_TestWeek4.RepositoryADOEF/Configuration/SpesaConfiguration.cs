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
    internal class SpesaConfiguration : IEntityTypeConfiguration<Spesa>
    {
        public void Configure(EntityTypeBuilder<Spesa> builder)
        {
            builder.ToTable("Spese");
            builder.HasKey(s => s.Id).HasName("PK_Spesa");
            builder.Property(s => s.Approvato).HasDefaultValue(true);
            builder.Property(s => s.Descrizione).HasDefaultValue("None");
            builder.Property(s => s.Data).HasDefaultValue(DateTime.Now);

            builder.HasOne(s => s.Categoria).WithMany(c => c.Spese).HasForeignKey(s => s.CategoriaId);

        }
    }
}
