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

        private DbContext _Context;
        PresencaRepository PresencaRepository;
        AulaRepository AulaRepository;
        TurmaRepository TurmaRepository;


        private IAraretamaCommonRepository<Aula, int> _repository = new AulaRepository(new BomNaEscolaBomDeBolaDbContext());
        public AulaController()
        {
            PresencaRepository = new PresencaRepository(new BomNaEscolaBomDeBolaDbContext());
            AulaRepository = new AulaRepository(new BomNaEscolaBomDeBolaDbContext());
            TurmaRepository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());

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
                Aula au = _repository.ByKey(aula.Id);
                au.DataEnvio = DateTime.Now;
                List<Presenca> presencas = aula.Presencas.FindAll(p => p.Presente);
                foreach (Presenca i in presencas)
                {
                    try
                    {
                        PresencaRepository.Update(i);
                    }
                    catch
                    {
                        PresencaRepository.Insert(i);
                    }

                }
                _repository.Update(au);
                return CreatedAtRoute("DefaultApi", new { controller = "aula", Id = aula.Id }, aula);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        // PUT api/values/5

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put([FromBody]Aula aula)
        {
            try
            {
                Aula au = _repository.ByKey(aula.Id);
                au.DataEnvio = DateTime.Now;
                foreach (Presenca i in aula.Presencas)
                {
                    try
                    {
                        PresencaRepository.Update(i);
                    }
                    catch
                    {
                        PresencaRepository.Insert(i);
                    }

                }
                _repository.Update(au);
                return CreatedAtRoute("DefaultApi", new { controller = "aula", Id = aula.Id }, aula);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

     
    }
}