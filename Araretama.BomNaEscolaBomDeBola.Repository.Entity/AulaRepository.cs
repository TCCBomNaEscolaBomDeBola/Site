using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.Common.Repository.Entity;
using System.Collections.Generic;
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
            aula.Turma = _context.Set<Turma>().Where(p => p.Id == aula.Turma.Id).FirstOrDefault();
            List<AlunoTurma> alunoTurma = _context.Set<AlunoTurma>().Where(p => p.Turma_Id == aula.Turma.Id).ToList();
            foreach (AlunoTurma at in alunoTurma)
            {
                aula.Turma.Alunos.Add(_context.Set<Aluno>().Where(p=> p.Id == at.Aluno_Id).FirstOrDefault());
            }
            aula.Presencas = new List<Presenca>();
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
                else
                {
                    pre.Aluno = i;
                }
                aula.Presencas.Add(pre);
            }
            
            return aula;
        }
       
    }
}
