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
    class AlunoTypeConfiguration : EntityTypeConfiguration<Aluno>
    {
        public AlunoTypeConfiguration()
        {
            ToTable("TB_ALUNO");
            Property(p => p.Id)
                .HasColumnName("ALU_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
            Property(p => p.IDTurma)
                .HasColumnName("TUR_ID")
                .IsRequired();
            Property(p => p.Nome)
                .HasColumnName("ALU_NOME")
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.DataNasc)
                .HasColumnName("ALU_DATANASC");
                
               

            Property(p => p.Escola)
                .HasColumnName("ALU_ESCOLA");

            Property(p => p.Serie)
                 .HasColumnName("ALU_SERIE");

            Property(p => p.Responsavel)
                 .HasColumnName("ALU_RESPONSAVEL");

            Property(p => p.Contato)
                .HasColumnName("ALU_CONTATO");

            Property(p => p.Logradouro)
                .HasColumnName("ALU_LOGRADOURO");

            Property(p => p.Numero)
                .HasColumnName("ALU_NUMERO");

            Property(p => p.Bairro)
                 .HasColumnName("ALU_BAIRRO");

            Property(p => p.Cidade)
                 .HasColumnName("ALU_CIDADE");

            Property(p => p.Estado)
                 .HasColumnName("ALU_ESTADO");

            Property(p => p.Cep)
               .HasColumnName("ALU_CEP");

            Property(p => p.Complemento)
                 .HasColumnName("ALU_COMPLEMENTO");


            Property(p => p.Observacao)
                .HasColumnName("ALU_OBSERVACAO");




        }

    }
}
