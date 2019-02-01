using Araretama.BomNaEscolaBomDeBola.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.TypeConfigurations
{
    public class AlunoTurmaTypeConfiguration : EntityTypeConfiguration<AlunoTurma>
    {
        public AlunoTurmaTypeConfiguration()
        {
            ToTable("TB_ALUTUR").HasKey(pf => new { pf.Turma_Id, pf.Aluno_Id });

            Property(p => p.Aluno_Id)
                .HasColumnName("ALU_ID")
                .IsRequired();

            Property(p => p.Turma_Id)
                .HasColumnName("TUR_ID")
                .IsRequired();


        }
    }
}
