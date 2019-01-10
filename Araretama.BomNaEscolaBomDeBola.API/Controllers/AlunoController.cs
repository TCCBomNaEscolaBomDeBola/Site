using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.API.Controllers
{
    public class AlunoController : ApiController
    {
        private DbContext _Context;

        TurmaRepository TurmaRepository;

        private IAraretamaCommonRepository<Aluno, int> _repository = new AlunoRepository(new BomNaEscolaBomDeBolaDbContext());

        public AlunoController()
        {
            TurmaRepository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());
        }

        [System.Web.Http.HttpGet]
        public List<Aluno> All()
        {
            return _repository.All();
        }

        [System.Web.Http.HttpGet]
        public Aluno GetAlunoByID(int key)
        {
            return _repository.ByKey(key);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Create([FromBody]Aluno aluno)
        {
            _repository.Insert(aluno);
            return CreatedAtRoute("DefaultApi", new { controller = "Aluno", id = aluno.Id }, aluno);

        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EditarAluno(Aluno aluno)
        {
            _repository.Update(aluno);
            return CreatedAtRoute("DefaultApi", new { controller = "Aluno", id = aluno.Id }, aluno);
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeletarAluno(Aluno aluno)
        {
            _repository.DeleteByKey(aluno.Id);
            return Ok();
        }


    }
}
