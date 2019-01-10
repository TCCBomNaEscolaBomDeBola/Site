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
    public class VoluntarioTypeConfiguration : EntityTypeConfiguration<Voluntario>
    {

        public VoluntarioTypeConfiguration()
        {
            ToTable("TB_VOLUNTARIO");
            Property(p => p.Id)
                .HasColumnName("VOL_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(p => p.IDTurma)
               .HasColumnName("TUR_ID")
               .IsRequired();
            Property(p => p.Nome)
                .HasColumnName("VOL_NOME")
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Contato)
               .HasColumnName("VOL_CONTATO");

            Property(p => p.Email)
               .HasColumnName("VOL_EMAIL");


            Property(p => p.Senha)
              .HasColumnName("VOL_SENHA");





        }
    }
}
