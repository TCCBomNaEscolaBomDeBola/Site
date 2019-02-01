using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class AlunoTurma
    {
        public AlunoTurma()
        {
            //Turmas = new List<Turma>();

        }
        [DisplayName("Aluno")]
        public int? Aluno_Id { get; set; }

        [DisplayName("Turma")]
        public int? Turma_Id { get; set; }

        [NotMapped]
        [DisplayName("Turma")]
        public virtual Turma Turma { get; set; }

        [NotMapped]
        [DisplayName("Aluno")]
        public virtual Aluno Aluno { get; set; }
    }
}
