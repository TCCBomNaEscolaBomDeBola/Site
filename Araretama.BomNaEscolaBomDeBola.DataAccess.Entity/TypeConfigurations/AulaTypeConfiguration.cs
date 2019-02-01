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
    public class AulaTypeConfiguration : EntityTypeConfiguration<Aula>
    {
        public AulaTypeConfiguration()
        {
            ToTable("TB_AULA");
              

            Property(p => p.Id)
                    .HasColumnName("AUL_ID")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();

            Property(p => p.TurmaID)
                            .HasColumnName("TUR_ID")
                            .IsOptional();

            Property(p => p.DataEnvio)
                 .HasColumnName("AUL_DATAENVIO")
                 .IsOptional();

            Property(p => p.DataAula)
                 .HasColumnName("AUL_DATAAULA")
                 .IsOptional();

        }
    }
}
