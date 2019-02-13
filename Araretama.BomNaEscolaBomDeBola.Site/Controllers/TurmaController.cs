
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
    public class TurmaController : Controller
    {
        private DbContext _Context;
        AlunoRepository AlunoRepository;
        VoluntarioRepository VoluntarioRepository;

        private IAraretamaCommonRepository<Turma, int> _repository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());
        
        public TurmaController()
        {
            AlunoRepository = new AlunoRepository(new BomNaEscolaBomDeBolaDbContext());
            VoluntarioRepository = new VoluntarioRepository(new BomNaEscolaBomDeBolaDbContext());
        }

        // GET: Turma
        public ActionResult Index()
        {
           
            List<Turma> a = _repository.All();
            foreach (var i in a)
            {
                i.Alunos = AlunoRepository.AlunosTurma(i.Id);
                i.Voluntarios = VoluntarioRepository.VoluntarioTurma(i.Id);
                i.QuantidadeDeAlunos = i.Alunos.Count();
            }
            return View(a);
        }

        // GET: Presenca/Details/5
        public ActionResult Details(int id)
        {
            Turma turma = _repository.ByKey(id);
            turma.Alunos = AlunoRepository.AlunosTurma(id);
            turma.Voluntarios = VoluntarioRepository.VoluntarioTurma(id);
            turma.QuantidadeDeAlunos = turma.Alunos.Count();
            return View(turma);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Turma turma, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Insert(turma);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
        
        public ActionResult Edit(int id)
        {
            return View(_repository.ByKey(id));
        }

        [HttpPost]
        public ActionResult Edit(int id,Turma turma, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    turma.Id = id;
                    _repository.Update(turma);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Turma turma = _repository.ByKey(id);
            turma.Alunos = AlunoRepository.AlunosTurma(id);
            turma.Voluntarios = VoluntarioRepository.VoluntarioTurma(id);
            turma.QuantidadeDeAlunos = turma.Alunos.Count();
            return View(turma);
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
                Turma turma = _repository.ByKey(id);
                turma.Alunos = AlunoRepository.AlunosTurma(id);
                turma.Voluntarios = VoluntarioRepository.VoluntarioTurma(id);
                 turma.QuantidadeDeAlunos = turma.Alunos.Count();
                return View(turma);

            }
        }
    }
}
