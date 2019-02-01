using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TurmaController : ApiController
    {

        AlunoRepository AlunoRepository;
        VoluntarioRepository VoluntarioRepository;


        private DbContext _Context;

        private IAraretamaCommonRepository<Turma, int> _repository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());
        public TurmaController()
        {
            AlunoRepository = new AlunoRepository(new BomNaEscolaBomDeBolaDbContext());
            VoluntarioRepository = new VoluntarioRepository(new BomNaEscolaBomDeBolaDbContext());

        }


        [System.Web.Http.HttpGet]
        public List<Turma> Get()
        {

            List<Turma> a = _repository.All();
            return a;
        }

        // GET api/values/
        [System.Web.Http.HttpGet]
        public Turma Get(int id)
        {
            Turma turma = _repository.ByKey(id);
            turma.Alunos = AlunoRepository.AlunosTurma(id);
            turma.Voluntarios = VoluntarioRepository.VoluntarioTurma(id);
            return turma;
        }

    }
}