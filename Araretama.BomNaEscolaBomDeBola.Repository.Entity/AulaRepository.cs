using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.Common.Repository.Entity;
using System.Data.Entity;
using System.Linq;

namespace Araretama.BomNaEscolaBomDeBola.Repository.Entity
{
    public class AulaRepository : AbstractRepository<Aula, int>
    {

        private DbContext _context;


        public AulaRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public Aula DetalhesAula(int IdAula)
        {
            Aula aula = new Aula();
            aula = _context.Set<Aula>().Where(p => p.Id == IdAula).FirstOrDefault();
            aula.Turma = _context.Set<Turma>().Where(p => p.Id == aula.IDTurma).FirstOrDefault();
            aula.Turma.Alunos = _context.Set<Aluno>().Where(p => p.IDTurma == aula.IDTurma).ToList();
            aula.Turma.Voluntarios = _context.Set<Voluntario>().Where(p => p.IDTurma == aula.IDTurma).ToList();
            aula.Presencas = new System.Collections.Generic.List<Presenca>();
            foreach (var i in aula.Turma.Alunos)
            {
                Presenca pre;
                pre = _context.Set<Presenca>().Where(p => p.IDAluno == i.Id & p.IDAula == aula.Id).FirstOrDefault();
                if (pre == null) {
                    pre = new Presenca();
                    pre.Aluno = i;
                    pre.IDAluno = i.Id;
                    pre.IDAula = aula.Id;

                }
                aula.Presencas.Add(pre);
            }
            
            return aula;
        }
       
    }
}
