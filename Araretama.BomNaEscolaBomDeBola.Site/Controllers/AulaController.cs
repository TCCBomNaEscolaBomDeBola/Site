using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Araretama.BomNaEscolaBomDeBola.Site.Controllers
{
    public class AulaController : Controller
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

       

        // GET: Aula
        public ActionResult Index(int? page, string sortOrder = "", string currentFilter = "", string searchString = "")
        {
            List<Aula> a = _repository.All().OrderBy(x => x.DataAula).ToList(); ;
            
            return View(a.ToPagedList((page ?? 1), 10));
        }

        // GET: Aula/Details/5
        public ActionResult Details(int id)
        {
            return View(AulaRepository.DetalhesAula(id));
        }

        // GET: Aula/Create
        public ActionResult Create()
        {
            List<Turma> Turmas = TurmaRepository.All();
            ViewBag.turmas = Turmas;
            return View();
        }

        // POST: Aula/Create
        [HttpPost]
        public ActionResult Create(Aulas aulas, FormCollection collection)
        {
            try
            {
                Turma turma = TurmaRepository.ByKey(aulas.IDTurma);
               
                int dia = this.DiaDaSemana(turma.DiaSemana);

                while (aulas.DataInicial <= aulas.DataFinal)
                {
                    if ((int)aulas.DataInicial.DayOfWeek == dia)
                    {
  
                        Aula aula = new Aula();
                        aula.DataAula = aulas.DataInicial;
                        aula.TurmaID = aulas.IDTurma;
                      //  aula.Turma = TurmaRepository.ByKey(aulas.IDTurma);
                        aula.DataEnvio = DateTime.Now;

                        _repository.Insert(aula);

                    }

                    aulas.DataInicial = aulas.DataInicial.AddDays(1);
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                List<Turma> Turmas = TurmaRepository.All();
                ViewBag.turmas = Turmas;
                return View();
            }
        }

        private int DiaDaSemana(string dia)
        {
            if (dia.Equals("Domingo")){
                return 0;
            }
            else 
            if (dia.Equals("Segunda-Feira"))
            {
                return 1;
            }
            else 
            if(dia.Equals("Terça-Feira"))
            {
                return 2;
            }
            else 
            if (dia.Equals("Quarta-Feira"))
            {
                return 3;
            }
            else
            if (dia.Equals("Quinta-Feira"))
            {
                return 4;
            }
            else
            if (dia.Equals("Sexta-Feira"))
            {
                return 5;
            }
            else
            if (dia.Equals("Sábado"))
            {
                return 6;
            }
                  
            return 0;
        }


        // GET: Aula/Chamada
        public ActionResult Chamada(int id)
        {
            return View(AulaRepository.DetalhesAula(id));
        }

        // POST: Aula/Chamada
        [HttpPost]
        public ActionResult Chamada(int id, Aula aula, FormCollection collection)
        {
            try
            {
                aula.DataAula = Convert.ToDateTime(collection["DataAula"]);
                aula.Id = id;
                aula.TurmaID = aula.Turma.Id;
                aula.DataEnvio = DateTime.Now;
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
                _repository.Update(aula);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["erro"] = "Não foi possível salvar os dados, tente novament";
                return View(AulaRepository.DetalhesAula(id));
            }
        }

        // GET: Aula/Edit/5
        public ActionResult Edit(int id)
        {
            return View(AulaRepository.DetalhesAula(id));
        }

        // POST: Aula/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aula aula,FormCollection collection)
        {
            try
            {
                Aula au = _repository.ByKey(id);
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
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["erro"] = "Não foi possível salvar os dados, tente novament";
                return View(AulaRepository.DetalhesAula(id));
            }
        }

        // GET: Aula/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.ByKey(id));
        }

        // POST: Aula/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Aula aula, FormCollection collection)
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
