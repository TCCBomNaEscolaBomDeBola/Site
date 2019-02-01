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
    public class TurmaTypeConfiguration : EntityTypeConfiguration<Turma>
    {
        public TurmaTypeConfiguration()
        {
            ToTable("TB_TURMA");
            Property(p => p.Id)
                    .HasColumnName("TUR_ID")
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .IsRequired();
            Property(p => p.DiaSemana)
                   .HasColumnName("TUR_DIASEMANA");
            Property(p => p.HorarioInicial)
                  .HasColumnName("TUR_HORARIOINICIAL");
            Property(p => p.HorarioFinal)
                  .HasColumnName("TUR_HOORARIOFINAL");
            Property(p => p.IdadeMaxima)
                  .HasColumnName("TUR_IDADEMAXIMA");
            Property(p => p.IdadeMinima)
                .HasColumnName("TUR_IDADEMINIMA");
            Property(p => p.Nome)
                .HasColumnName("TUR_NOME");

        }
    }
}
