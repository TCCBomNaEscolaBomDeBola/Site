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
    public class VoluntarioController : ApiController
    {

        public VoluntarioController(){
            }
        // GET: Voluntario
        private DbContext _Context;

        private IAraretamaCommonRepository<Voluntario, int> _repository = new VoluntarioRepository(new BomNaEscolaBomDeBolaDbContext());

        [System.Web.Http.HttpGet]
        public List<Voluntario> Get()
        {
            return _repository.All();
        }

        [System.Web.Http.HttpGet]
        public Voluntario Get(int id)
        {
            return _repository.ByKey(id);
        }


        [EnableCors(origins: "*", methods: "*", headers: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody]Voluntario voluntario)
        {
            try
            {
                _repository.Insert(voluntario);
                return CreatedAtRoute("DefaultApi", new { controller = "Voluntario", id = voluntario.Id }, voluntario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/values/5
        
        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Voluntario voluntario)
        {
            try
            {
                _repository.Update(voluntario);
                return CreatedAtRoute("DefaultApi", new { controller = "Voluntario", Id = voluntario.Id }, voluntario);

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


    }
}