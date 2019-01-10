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
        public ActionResult Index(int? page, string sortOrder="", string currentFilter="", string searchString="")
        {
            List<Aluno> a = _repository.All();
            return View(a.ToPagedList((page ?? 1), 5));
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
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno, FormCollection collection)
        {
            try
            {
                

                _repository.Insert(aluno);
                return RedirectToAction("Index");
            }
            catch
            {

                List<Turma> Turmas = TurmaRepository.All();
                ViewBag.turmas = Turmas;
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Aluno aluno = new Aluno
                {
                    Bairro = collection["bairro"],
                    Cep = collection["cep"],
                    Cidade = collection["cidade"],
                    Complemento = collection["complemento"],
                    Contato = collection["contato"],
                    DataNasc = collection["dataNasc"],
                    Escola = collection["escola"],
                    Estado = collection["estado"],
                    Logradouro = collection["logradouro"],
                    Nome = collection["nome"],
                    Numero = collection["numero"],
                    Observacao = collection["observacao"],
                    Responsavel = collection["responsavel"],
                    Serie = collection["serie"]
                };

                aluno.Id = id;
                _repository.Update(aluno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
    }
}

