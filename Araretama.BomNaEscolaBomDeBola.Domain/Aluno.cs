using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Aluno
    {
       
        public int Id { get; set; }

        public int IDTurma { get; set; }

        public Turma Turma { get; set; }

        /*  [Required(ErrorMessage = "O nome deve ser informado")]
          [DisplayName("Nome")]
       
        [StringLength(100, MinimumLength = 5)]
       */
        
        public string Nome { get; set; }


        /*   [Required(ErrorMessage = "O nome deve ser informado")]
          [DisplayName("Data de Nascimento")]
          [StringLength(100, MinimumLength = 5)]
       */
        public string DataNasc { get; set; }


    /*     [DisplayName("Escola")]
        [StringLength(100, MinimumLength = 5)]
    */    public string Escola { get; set; }

    //    [DisplayName("Serie")]
        public string Serie { get; set; }

     //   [DisplayName("Responsável")]
        public string Responsavel { get; set; }

     //   [DisplayName("Contato")]
        public string Contato { get; set; }

        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

    //    [DisplayName("Número")]
        public string Numero { get; set; }

   //     [DisplayName("CEP")]
   //     [RegularExpression(@"^\d{8}$|^\d{5}-\d{3}$", ErrorMessage = "O código postal deverá estar no formato 00000000 ou 00000-000")]
        public string Cep { get; set; }

     //   [DisplayName("Bairro")]
        public string Bairro { get; set; }

     //   [DisplayName("Cidade")]
        public string Cidade { get; set; }

    //    [DisplayName("Estado")]
        public string Estado { get; set; }

     //   [DisplayName("Complemento")]
        public string Complemento { get; set; }

    //    [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
}


