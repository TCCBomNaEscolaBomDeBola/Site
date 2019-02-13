using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Timers;
using System.Web;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Turma
    {
        public Turma()
        {
           Alunos = new List<Aluno>();
           Voluntarios = new List<Voluntario>();
        }


        public int Id { get; set; }


        [Required(ErrorMessage = "O nome da turma deve ser informado")]
        [DisplayName("Turma")]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A idade mínima deve ser informada")]
        [DisplayName("Idade Mínima")]
        [Range(0, 99)]
        public int IdadeMinima { get; set; }

        [Required(ErrorMessage = "A idade máxima deve ser informada")]
        [DisplayName("Idade Máxima")]
        [Range(0, 99)]
        public int IdadeMaxima { get; set; }



        [DisplayName("Horário Inicial")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioInicial { get; set; }

        [DisplayName("Horário Final")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioFinal { get; set; }

        [DisplayName("Dia da Semana")]
        public string DiaSemana { get; set; }

        [DisplayName("Alunos")]
        public virtual List<Aluno> Alunos { get; set; }


        [DisplayName("Voluntários")]
        public virtual List<Voluntario> Voluntarios { get; set; }

        [DisplayName("Quantidade de Aluno")]
        [Range(0, 1000)]
        [NotMapped]
        public int QuantidadeDeAlunos { get; set; }

        [DisplayName("Quantidade de Aluno")]
        [Range(0, 1000)]
        [NotMapped]
        public int QuantidadeDeVoluntarios { get; set; }
    }
}