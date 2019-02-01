
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
        public ActionResult Index(int? page, string sortOrder = "", string currentFilter = "", string searchString = "")
        {
           
            List<Turma> a = _repository.All();
            return View(a.ToPagedList((page ?? 1), 10));
        }

        // GET: Presenca/Details/5
        public ActionResult Details(int id)
        {
            Turma turma = _repository.ByKey(id);
            turma.Alunos = AlunoRepository.AlunosTurma(id);
            turma.Voluntarios = VoluntarioRepository.VoluntarioTurma(id);
            return View(turma);
        }
        // GET: Turma/Create
        public ActionResult Create()
        {

          

            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        public ActionResult Create(Turma turma, FormCollection collection)
        {
            try
            {
                /*

                var enumData = from Dia e in Enum.GetValues(typeof(Dia))
                               select new
                               {
                                   ID = e.ToString(),
                                   Name = e.ToString()
                               };

                ViewBag.DiaSemana = new SelectList(enumData, "ID", "Name");


                 foreach (var item in Turmas)
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



                /* Turma turma = new Turma
                 {
                     HorarioFinal = Convert.ToDateTime(collection["HorarioFinal"]),
                     HorarioInicial = Convert.ToDateTime(collection["HorarioInicial"]),
                     IdadeMaxima = Convert.ToInt32(collection["IdadeMaxima"]),
                     IdadeMinima = Convert.ToInt32(collection["IdadeMinima"]),
                     Nome = collection["Nome"]

                 };*/
                if (ModelState.IsValid)
                {

                    _repository.Insert(turma);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(turma);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Turma/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Turma turma, FormCollection collection)
        {
            try
            {
                /*  Turma turma = new Turma
                {
                    DiaSemana = collection["DiaSemana"],
                    HorarioFinal = Convert.ToDateTime(collection["HorarioFinal"]),
                    HorarioInicial = Convert.ToDateTime(collection["HorarioInicial"]),
                    IdadeMaxima = Convert.ToInt32(collection["IdadeMaxima"]),
                    IdadeMinima = Convert.ToInt32(collection["IdadeMinima"]),
                    Nome = collection["Nome"]

                };*/
                turma.Id = id;
                _repository.Update(turma);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Turma/Delete/5
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
