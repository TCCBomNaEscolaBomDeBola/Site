using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.Common.Repository.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Araretama.BomNaEscolaBomDeBola.Repository.Entity
{
    public class TurmaRepository : AbstractRepository<Turma, int>
    {
        private DbContext _context;

        public TurmaRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }


    }
}
