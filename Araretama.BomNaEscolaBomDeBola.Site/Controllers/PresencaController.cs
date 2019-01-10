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
   
    public class PresencaController : Controller
    {

        private DbContext _Context;

        private IAraretamaCommonRepository<Presenca, int> _repository = new PresencaRepository(new BomNaEscolaBomDeBolaDbContext());


        public ActionResult Index(int? page, string sortOrder = "", string currentFilter = "", string searchString = "")
        {
            List<Presenca> a = _repository.All();
            return View(a.ToPagedList((page ?? 1), 5));
        }

        // GET: Presenca/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.ByKey(id));
        }

        // GET: Presenca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Presenca/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Presenca presenca = new Presenca
                {
                    IDAluno = Convert.ToInt32(collection["IDAluno"]),
                    IDAula = Convert.ToInt32(collection["IDAula"]),
                    Presente = Convert.ToBoolean(collection["Presente"])

                };

                _repository.Insert(presenca);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Presenca/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Presenca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Presenca presenca = new Presenca
                {
                    IDAluno = Convert.ToInt32(collection["IDAluno"]),
                    IDAula = Convert.ToInt32(collection["IDAula"]),
                    Presente = Convert.ToBoolean(collection["Presente"])

                };
                presenca.id = id;

                _repository.Update(presenca);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Presenca/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Presenca/Delete/5
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
