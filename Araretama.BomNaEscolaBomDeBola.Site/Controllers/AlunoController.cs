﻿using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.Site.Controllers
{
  //  [Authorize(Roles = "Administrador")]
    public class AlunoController : Controller
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



        // GET: Aluno
        public ActionResult Index(int? page, string ordemLetra="", string searchString="")
        {
            List<Aluno> alunos =  _repository.All();

            if (ordemLetra.Trim() != "")
            {
                alunos = alunos.Where(p=> (p.Nome.ToUpper().StartsWith(ordemLetra.ToUpper()))).ToList();
                alunos.OrderBy(p => p.Nome);
            }
            if (searchString.Trim() != "")
            {
                alunos = alunos.Where(p => (p.Nome.ToUpper().Contains(searchString.ToUpper()))).ToList();
                alunos.OrderBy(p => p.Nome);
            }


            return View(alunos.ToPagedList((page ?? 1), 12));
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            Aluno aluno = _repository.ByKey(id);
            List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
            foreach (var alt in at)
            {
                aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
            }
            if (aluno.Turmas.Count < 1)
            {
                aluno.Turmas.Add(new Turma());
            }
            return View(aluno);
        }



        // GET: Aluno/Create
        public ActionResult Create()
        {


          //  List<SelectListItem> lista_turmas = new List<SelectListItem>();

            List<Turma> Turmas = TurmaRepository.All();

        
           /* foreach (var item in Turmas)
            {
  
                lista_turmas.Add(
                    new SelectListItem()
                    {
                        Text = item.Nome,
                        Value = item.Id.ToString(),
                    });
            }
            SelectList dropDown = new SelectList(lista_turmas, "Value", "Text");
  */

            ViewBag.turmas = Turmas;
            //   ViewBag.lista_turmas2 = dropDown;
            //   ViewBag.lista_turmas = lista_turmas;
            Aluno aluno = new Aluno();
            aluno.Turmas = new List<Turma>();
            aluno.Turmas.Add(new Turma());
            return View(aluno);
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno, List<Turma> turmas, FormCollection collection)
        {
            try
            {
                aluno.Turmas = new List<Turma>();

                _repository.Insert(aluno);
                for (int i = 0; i < turmas.Count; i++)
                {
                    AlunoTurma at = new AlunoTurma();
                    at.Aluno_Id = aluno.Id;
                    at.Turma_Id = turmas[i].Id;
                    AlunoTurmaRepository.Insert(at);
                   
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                List<Turma> Turmas = TurmaRepository.All();
                ViewBag.turmas = Turmas;
                return View(aluno);
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            Aluno aluno = _repository.ByKey(id);
            List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
            foreach (var alt in at)
            {
                aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
            }
            if (aluno.Turmas.Count < 1)
            {
               aluno.Turmas.Add(new Turma());
            }
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno aluno, List<Turma> turmas, FormCollection collection)
        {
            try
            {
                
                aluno.Turmas = new List<Turma>();
                aluno.Turmas = turmas;
                _repository.Update(aluno);
                List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
                if (at.Count() > 0)
                {
                    for (int i = 0; i < at.Count ; i++)
                    {
                        AlunoTurmaRepository.Delete(at[i]);
                    }
                }

                for (int j = 0; j < turmas.Count ; j++)
                {
                    if((AlunoTurmaRepository.All().Where(p=> p.Aluno_Id == aluno.Id && p.Turma_Id == turmas[j].Id).ToList().Count) <= 0)
                    {
                        AlunoTurmaRepository.Insert(new AlunoTurma()
                        {
                            Aluno_Id = aluno.Id,
                            Turma_Id = turmas[j].Id
                        });
                    }
                  
                }
                              


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                List<Turma> Turmas = TurmaRepository.All();
                ViewBag.turmas = Turmas;
                return View(aluno);
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            Aluno aluno = _repository.ByKey(id);
            List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == aluno.Id).ToList();
            foreach (var alt in at)
            {
                aluno.Turmas.Add(Turmas.Where(p => p.Id == alt.Turma_Id).FirstOrDefault());
            }
            if (aluno.Turmas.Count < 1)
            {
                aluno.Turmas.Add(new Turma());
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<AlunoTurma> at = AlunoTurmaRepository.All().Where(p => p.Aluno_Id == id).ToList();
                if (at.Count() > 0)
                {
                    for (int i = 0; i < at.Count; i++)
                    {
                        AlunoTurmaRepository.Delete(at[i]);
                    }
                }
                _repository.DeleteByKey(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(_repository.ByKey(id));

            }
        }

   
        public ActionResult CreateTurma()
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            Turma turma = new Turma();
            return PartialView("Turmas", turma);
        }
    }
}

