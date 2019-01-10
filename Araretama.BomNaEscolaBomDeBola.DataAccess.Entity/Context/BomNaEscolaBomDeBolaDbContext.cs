using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.TypeConfigurations;
using Araretama.BomNaEscolaBomDeBola.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context
{
    public class BomNaEscolaBomDeBolaDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        //    base.OnModelCreating(modelBuilder);


            modelBuilder.Configurations.Add(new AlunoTypeConfiguration());
            modelBuilder.Configurations.Add(new VoluntarioTypeConfiguration());
            modelBuilder.Configurations.Add(new TurmaTypeConfiguration());
            modelBuilder.Configurations.Add(new PresencaTypeConfiguration());
            modelBuilder.Configurations.Add(new AulaTypeConfiguration());
        }
    }
}
