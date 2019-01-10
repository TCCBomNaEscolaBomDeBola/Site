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
            return _context.Set<Aluno>().Where(p => p.Id == IdTurma).ToList();
        }
        public int QuantidadeAlunosTurma(int IdTurma)
        {
            try
            {
                return _context.Set<Aluno>().Count(p => p.IDTurma == IdTurma);
            }
            catch
            {
                return 0;
            }
           
        }
    }

   
}
