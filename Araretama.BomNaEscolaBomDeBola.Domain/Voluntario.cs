﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Voluntario
    {
        public int Id { get; set; }

        [DisplayName("Turma")]
        public int IDTurma { get; set; }

        
        public ICollection<Turma> Turma { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado")]
        [DisplayName("Nome")]
        public string Nome { get; set; }
        

        [Required(ErrorMessage = "A senha deve ser informado")]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O login deve ser informado")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

      //  [Required]
        [DisplayName("Contato")]
        public string Contato { get; set; }


        public virtual List<Voluntario> Voluntarios { get; set; }
    }
}