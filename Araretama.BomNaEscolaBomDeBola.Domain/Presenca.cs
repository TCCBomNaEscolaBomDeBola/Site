using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Presenca
    {
        [Required]
        [DisplayName("Codigo")]
        public int id { get; set; }

        [DisplayName("Aluno")]
        public virtual Aluno Aluno { get; set; }

       [Required]
       [DisplayName("Aluno")]
       public int IDAluno { get; set; }

        [Required]
        [DisplayName("Presença")]
        public bool Presente { get; set; }

        [DisplayName("Aluno")]
        public virtual Aula Aula { get; set; }


          [Required]
          [DisplayName("Aula")]
          public int IDAula { get; set; }
    }
}

