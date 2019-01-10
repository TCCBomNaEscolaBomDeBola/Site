
using Araretama.BomNaEscolaBomDeBola.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.TypeConfigurations
{
    public class PresencaTypeConfiguration : EntityTypeConfiguration<Presenca>
    {
        public PresencaTypeConfiguration()
        {
            ToTable("TB_PRESENCA");
            Property(p => p.id)
                    .HasColumnName("PRE_ID")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();
            Property(p => p.IDAluno)
                   .HasColumnName("ALU_ID");
            Property(p => p.IDAula)
                   .HasColumnName("AUL_ID");
            Property(p => p.Presente)
                .HasColumnName("PRE_PRESENCA");


        }
    }
}
