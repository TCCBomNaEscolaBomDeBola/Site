using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
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

        private IAraretamaCommonRepository<Aluno, int> _repository = new AlunoRepository(new BomNaEscolaBomDeBolaDbContext());

        public AlunoController()
        {
            TurmaRepository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());

        }



        // GET: Aluno
        public ActionResult Index(int? pagina, string ordemLetra="", string searchString="")
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


            return View(alunos.ToPagedList((pagina ?? 1), 12));
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.ByKey(id));
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
            aluno.Turma.Add(new Turma());
            return View(aluno);
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno, List<Turma> turmas, FormCollection collection)
        {
            try
            {



                _repository.Insert(aluno);
                
                foreach (Turma t in turmas)
                {
                    Turma tur = TurmaRepository.ByKey(Convert.ToInt32(t.Id));
                    tur.Alunos = new List<Aluno>();
                    tur.Alunos.Add(aluno);
                    tur.Voluntarios = new List<Voluntario>();
                    aluno.Turma.Add(tur);
                    TurmaRepository.Update(tur);


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
            if (aluno.Turma.Count < 1)
            {
                aluno.Turma.Add(new Turma());
            }
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno aluno, List<Turma> turmas, FormCollection collection)
        {
            try
            {
                _repository.Update(aluno);
                aluno.Turma = new List<Turma>();
                foreach (Turma t in turmas)
                {
                    Turma tur = TurmaRepository.ByKey(Convert.ToInt32(t.Id));
                    tur.Alunos = new List<Aluno>();
                    tur.Voluntarios = new List<Voluntario>();
                    tur.Alunos[tur.Alunos.IndexOf(tur.Alunos.Where(p => p.Id == aluno.Id).FirstOrDefault())] = aluno;
                    aluno.Turma.Add(tur);
                    TurmaRepository.Update(tur);
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
            return View(_repository.ByKey(id));
        }

        // POST: Aluno/Delete/5
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

   
        public ActionResult CreateTurma()
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            Turma turma = new Turma();
            return PartialView("Turmas", turma);
        }
    }
}

