using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.Site.Controllers
{
   // [Authorize(Roles = "Administrador")]
    public class VoluntarioController : Controller
    {
        private DbContext _Context;
        TurmaRepository TurmaRepository;

        private IAraretamaCommonRepository<Voluntario, int> _repository = new VoluntarioRepository(new BomNaEscolaBomDeBolaDbContext());

        public VoluntarioController()
        {
            TurmaRepository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());
        }

        public ActionResult Index()
        {
            return View(_repository.All());
        }

        public ActionResult Details(int id)
        {
            Voluntario voluntario = _repository.ByKey(id);
            voluntario.Turma.Add(TurmaRepository.All().Where(p => p.Id == voluntario.IDTurma).FirstOrDefault());
            return View(voluntario);
        }


        public ActionResult Create()
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Voluntario voluntario, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Insert(voluntario);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    List<Turma> Turmas = TurmaRepository.All();
                    ViewBag.turmas = Turmas;

                    return View(voluntario);
                }
            }
            return View(voluntario);
        }
        
        public ActionResult Edit(int id)
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            Voluntario voluntario = _repository.ByKey(id);
            voluntario.Turma.Add(Turmas.Where(p => p.Id == voluntario.IDTurma).FirstOrDefault());
            return View(voluntario);
        }

        [HttpPost]
        public ActionResult Edit(int id, Voluntario voluntario, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(voluntario);
                    return RedirectToAction("Index");
                }
                catch
                {
                    List<Turma> Turmas = TurmaRepository.All();
                    ViewBag.turmas = Turmas;
                    return View(voluntario);
                }
            }
            return View(voluntario);
        }
        
        public ActionResult Delete(int id)
        {
            Voluntario voluntario = _repository.ByKey(id);
            voluntario.Turma.Add(TurmaRepository.All().Where(p => p.Id == voluntario.IDTurma).FirstOrDefault());
            return View(voluntario);
        }
        
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.DeleteByKey(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(_repository.ByKey(id));

            }
        }
    }
}
