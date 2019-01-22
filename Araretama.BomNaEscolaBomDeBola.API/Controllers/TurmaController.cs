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
            return _repository.ByKey(id);
        }

       /* // POST api/values
        [EnableCors(origins: "*", methods: "*", headers: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody]Turma turma)
        {
            try
            {
                _repository.Insert(turma);
                return CreatedAtRoute("DefaultApi", new { controller = "turma", id = turma.Id }, turma);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/values/5

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Turma turma)
        {
            try
            {
                _repository.Update(turma);
                return CreatedAtRoute("DefaultApi", new { controller = "turma", Id = turma.Id }, turma);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


        [EnableCors(origins: "*", methods: "*", headers: "*")]
        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _repository.DeleteByKey(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        */


     

    }
}