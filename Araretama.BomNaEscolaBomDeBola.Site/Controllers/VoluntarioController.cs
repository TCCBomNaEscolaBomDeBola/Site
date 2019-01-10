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

        private IAraretamaCommonRepository<Voluntario, int> _repository = new VoluntarioRepository(new BomNaEscolaBomDeBolaDbContext());

        // GET: Voluntario
        public ActionResult Index(int? page, string sortOrder = "", string currentFilter = "", string searchString = "")
        {
            List<Voluntario> a = _repository.All();
            return View(a.ToPagedList((page ?? 1), 5));
        }

        // GET: Voluntario/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.ByKey(id));
        }

        // GET: Voluntario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voluntario/Create
        [HttpPost]
        public ActionResult Create(Voluntario voluntario, FormCollection collection)
        {
            try
            {
                 _repository.Insert(voluntario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Voluntario/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Voluntario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Voluntario vol = new Voluntario
                {
                    Email = collection["Email"],
                    IDTurma = Convert.ToInt32(collection["IDTurma"]),
                    Senha = collection["Senha"]

                };
                vol.Id = id;

                _repository.Update(vol);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Voluntario/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Voluntario/Delete/5
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
