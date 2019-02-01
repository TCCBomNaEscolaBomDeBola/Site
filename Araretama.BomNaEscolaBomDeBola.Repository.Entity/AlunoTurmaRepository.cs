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

    public class AlunoTurmaRepository : AbstractRepository<AlunoTurma, int>
    {
        private DbContext _context;
        public AlunoTurmaRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
