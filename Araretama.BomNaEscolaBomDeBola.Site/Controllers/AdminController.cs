using System;
using Araretama.BomNaEscolaBomDeBola.DataAccess.Entity.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Araretama.BomNaEscolaBomDeBola.Domain;
using Araretama.BomNaEscolaBomDeBola.Repository.Entity;
using AraretamaRepositoy;
using System.Web.Mvc;
using System.Data.Entity;

namespace Araretama.BomNaEscolaBomDeBola.Site.Controllers
{
    public class AdminController : Controller
    {
        private DbContext _Context;

        AlunoRepository AlunoRepository;
        VoluntarioRepository VoluntarioRepository;
        TurmaRepository TurmaRepository;
        private IAraretamaCommonRepository<Turma, int> _repository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());

        public AdminController()
        {
            AlunoRepository = new AlunoRepository(new BomNaEscolaBomDeBolaDbContext());
            VoluntarioRepository = new VoluntarioRepository(new BomNaEscolaBomDeBolaDbContext());
            TurmaRepository = new TurmaRepository(new BomNaEscolaBomDeBolaDbContext());
        }

        public ActionResult Index()
        {
            ViewBag.aluno = AlunoRepository.All().Count();
            ViewBag.Voluntario = VoluntarioRepository.All().Count();
            ViewBag.Turma = TurmaRepository.All().Count();


            List<Turma> turmas = _repository.All();

            foreach (var i in turmas)
            {
                i.Alunos = AlunoRepository.AlunosTurma(i.Id);
                i.Voluntarios = VoluntarioRepository.VoluntarioTurma(i.Id);
                i.QuantidadeDeAlunos = i.Alunos.Count();
                i.QuantidadeDeVoluntarios = i.Voluntarios.Count();
            }


            return View(turmas);
        }
    }
}