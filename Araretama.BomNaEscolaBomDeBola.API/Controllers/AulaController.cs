using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.API.Controllers
{
    public class AulaController : ApiController
    {

        AulaRepository AulaRepository;
        PresencaRepository PresencaRepository;


        private DbContext _Context;

        private IAraretamaCommonRepository<Aula, int> _repository = new AulaRepository(new BomNaEscolaBomDeBolaDbContext());
        public AulaController()
        {
            PresencaRepository = new PresencaRepository(new BomNaEscolaBomDeBolaDbContext());
            AulaRepository = new AulaRepository(new BomNaEscolaBomDeBolaDbContext());

        }


        [System.Web.Http.HttpGet]
        public List<Aula> Get()
        {
            return _repository.All();
        }

        // GET api/values/
        [System.Web.Http.HttpGet]
        public Aula Get(int id)
        {
            return AulaRepository.DetalhesAula(id);
        }

        // POST api/values
      //  [EnableCors(origins: "*", methods: "*", headers: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody]Aula aula)
        {
            try
            {
                _repository.Insert(aula);
                return CreatedAtRoute("DefaultApi", new { controller = "aula", id = aula.Id }, aula);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/values/5

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Aula aula)
        {
            try
            {
                _repository.Update(aula);
                return CreatedAtRoute("DefaultApi", new { controller = "aula", Id = aula.Id }, aula);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


      //  [EnableCors(origins: "*", methods: "*", headers: "*")]
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
     

        // GET api/values/
        //[System.Web.Http.HttpGet]
        //public Aula Chamada(int id)
        //{
          //  return AulaRepository.DetalhesAula(id);
        //}

        // POST api/values
     //   [EnableCors(origins: "*", methods: "*", headers: "*")]
        //[System.Web.Http.HttpPost]
        /*public IHttpActionResult Chamada(int id, Aula aula, FormCollection collection)
        {
            try
            {
                foreach (var i in aula.Presencas)
                {
                    PresencaRepository.Insert(i);
                }
                aula.DataEnvio = DateTime.Now;
                _repository.Update(aula);


                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/


    }
}