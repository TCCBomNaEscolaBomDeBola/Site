using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.Common.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Araretama.BomNaEscolaBomDeBola.Repository.Entity
{
    public class AlunoRepository : AbstractRepository<Aluno, int>
    {
        private DbContext _context;

        public AlunoRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public List<Aluno> AlunosTurma(int IdTurma)
        {
            List<AlunoTurma> at = _context.Set<AlunoTurma>().Where(p => p.Turma_Id == IdTurma).ToList();
            List<Aluno> alunos = new List<Aluno>();
            foreach (var i in at)
            {
                alunos.Add(_context.Set<Aluno>().Where(p => p.Id == i.Aluno_Id).FirstOrDefault());
            }
            return alunos;
        }

        public void EditarAluno(Aluno aluno, Turma turma)
        {

            _context.Set<Aluno>().Add(aluno);

            _context.Set<Aluno>().Attach(aluno);


            _context.Set<Turma>().Add(turma);
            // 3
            _context.Set<Turma>().Attach(turma);

            // like previous method add instance to navigation property
          //  aluno.Turmas.Add(AlunoTurma);

            // call SaveChanges
            _context.SaveChanges();
        }

        public void getAluno (int key)
        {
            Aluno aluno =  _context.Set<Aluno>().Where(p => p.Id == key).FirstOrDefault();
          //  aluno.Turmas= new List<Turma>();
          //  aluno.Turma = _context.Set<Turma>().Where()
        //    return
        }
       
    }

   
}
