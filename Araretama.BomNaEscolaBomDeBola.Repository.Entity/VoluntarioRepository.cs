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
    public class VoluntarioRepository : AbstractRepository<Voluntario, int>
    {

         private DbContext _context;


        public VoluntarioRepository(DbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public Voluntario Login(Voluntario login)
        {
            return _context.Set<Voluntario>().Where(p => p.Senha == login.Senha & p.Email == login.Email).FirstOrDefault();
        }

        public List<Voluntario> VoluntarioTurma(int IdTurma)
        {
            return _context.Set<Voluntario>().Where(p => p.Id == IdTurma).ToList();
        }
        public int QuantidadeVoluntarioTurma(int IdTurma)
        {
            return _context.Set<Voluntario>().Count(p => p.Id == IdTurma);
        }

    }
}
