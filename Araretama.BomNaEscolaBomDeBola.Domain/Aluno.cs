using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Aluno
    {
        public Aluno()
        {
            Turma = new List<Turma>();

        }

        public int Id { get; set; }

        [DisplayName("Turma")]
        [Required(ErrorMessage = "O nome deve ser informado")]
        public virtual List<Turma> Turma { get; set; }

        /*  [Required(ErrorMessage = "O nome deve ser informado")]
          [DisplayName("Nome")]
       
        [StringLength(100, MinimumLength = 5)]
       */
        [Required(ErrorMessage = "O nome deve ser informado")]
        public string Nome { get; set; }


        [DisplayName("Data de Nascimento")]
        [StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string DataNasc { get; set; }


        [DisplayName("Escola")]
        [StringLength(100, MinimumLength = 5)]
        public string Escola { get; set; }

        [DisplayName("Série")]
        public string Serie { get; set; }

        [DisplayName("Responsável")]
        public string Responsavel { get; set; }

        [DisplayName("Contato")]
        [DataType(DataType.PhoneNumber)]
        public string Contato { get; set; }

        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        [DisplayName("CEP")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:##.###-###}")]
        public string Cep { get; set; }

        [DisplayName("Bairro")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        public string Cidade { get; set; }

        [DisplayName("Estado")]
        public string Estado { get; set; }

        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }
    }
    /*
    public class AlunoTurma{
        public int Id { get; set; }
        public int Id_Aluno { get; set; }
        public int Id_Turma{ get; set; }
    }
    */
}


