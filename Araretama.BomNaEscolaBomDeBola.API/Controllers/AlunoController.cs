using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.API.Controllers
{
    public class AlunoController : ApiController
    {
        private DbContext _Context;

        TurmaRepository TurmaRepository;
        AlunoTurmaRepository AlunoTurmaRepository;

        private IAraretamaCommonRepository<Aluno, int> _repository = new AlunoRepository(new BomNaEscolaBomDeBolaDbContext());

        public AlunoController()
        {
            TurmaRepository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());
            AlunoTurmaRepository = new AlunoTurmaRepository(new BomNaEscolaBomDeBolaDbContext());
        }

        [System.Web.Http.HttpGet]
        public List<Aluno> Get()
        { 
            List<Aluno> alunos = _repository.All();
            List<Turma> Turmas = TurmaRepository.All();
            foreach (Aluno alu in alunos)
            {
                List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == alu.Id).ToList();
                foreach (var alt in at)
                {
                    alu.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
                }

            }

            return alunos;
        }

        [System.Web.Http.HttpGet]
        public Aluno GetAlunoByID(int key)
        {
            List<Turma> Turmas = TurmaRepository.All();
            Aluno aluno = _repository.ByKey(key);
            List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
            foreach (var alt in at)
            {
                aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
            }
            return aluno;
        }
        // GET api/values/
        [System.Web.Http.HttpGet]
        public Aluno Get(int id)
        {
            List<Turma> Turmas = TurmaRepository.All();
            Aluno aluno = _repository.ByKey(id);
            List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
            foreach (var alt in at)
            {
                aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
            }
            return aluno;
        }

        [EnableCors(origins: "*", methods: "*", headers: "*")]
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody]Aluno aluno)
        {
            try
            {
                List<Turma> turmas = new List<Turma>();
                turmas = aluno.Turmas;
                aluno.Turmas = new List<Turma>();
                _repository.Insert(aluno);

                for (int i = 0; i < turmas.Count; i++)
                {
                    AlunoTurma at = new AlunoTurma();
                    at.Aluno_Id = aluno.Id;
                    at.Turma_Id = turmas[i].Id;
                    AlunoTurmaRepository.Insert(at);

                }
                List<Turma> Turmas = TurmaRepository.All();
                List<AlunoTurma> at2 = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
                foreach (var alt in at2)
                {
                    aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
                }
                return CreatedAtRoute("DefaultApi", new { controller = "Aluno", id = aluno.Id }, aluno);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put(Aluno aluno)
        {
            try
            {
                List<Turma> turmas = new List<Turma>();
                turmas = aluno.Turmas;
                aluno.Turmas = new List<Turma>();
                _repository.Update(aluno);
                List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
                if (at.Count() > 0)
                {
                    for (int i = 0; i < at.Count; i++)
                    {
                        AlunoTurmaRepository.Delete(at[i]);
                    }
                }

                for (int j = 0; j < turmas.Count; j++)
                {
                    if ((AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id && p.Turma_Id == turmas[j].Id).ToList().Count) <= 0)
                    {
                        AlunoTurmaRepository.Insert(new AlunoTurma()
                        {
                            Aluno_Id = aluno.Id,
                            Turma_Id = turmas[j].Id
                        });
                    }

                }
                List<Turma> Turmas = TurmaRepository.All();
                List<AlunoTurma> at2 = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
                foreach (var alt in at2)
                {
                    aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
                }
                return CreatedAtRoute("DefaultApi", new { controller = "Aluno", id = aluno.Id }, aluno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
           
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(Aluno aluno)
        {
            try
            {
                List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
                if (at.Count() > 0)
                {
                    for (int i = 0; i < at.Count; i++)
                    {
                        AlunoTurmaRepository.Delete(at[i]);
                    }
                }
                _repository.DeleteByKey(aluno.Id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


    }
}
