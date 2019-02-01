using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Aula
    {
        public Aula()
        {
            this.Presencas = new List<Presenca>();
        }


        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Data da Aula")]
        [DataType(DataType.Date)]
        public DateTime DataAula{ get; set; }

        [DisplayName("Data do envio")]
        [DataType(DataType.DateTime)]
        public DateTime? DataEnvio { get; set; }

        
        [DisplayName("Presenças")]
        public virtual List<Presenca> Presencas { get; set; }

        //   [DataType(DataType.Time)]
        //  [DisplayName("Horário")]
        //  public DateTime? Horario { get; set; }
        [DisplayName("Turma")]
        public int?  TurmaID { get; set; }


        [DisplayName("Turma")]
        public virtual Turma Turma { get; set; }

        [NotMapped]
        [DisplayName("Alunos Presentes")]
        public int AlunosPresentes
        {
            get
            {
                try
                {
                    return Presencas.Where(p => p.Presente).ToList().Count();
                }
                catch
                {
                    return 0;
                }

             
                
            }
        }

    }


}

