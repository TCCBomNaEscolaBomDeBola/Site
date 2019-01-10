using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Araretama.BomNaEscolaBomDeBola.Domain
{
    public class Aulas
    {
        [DisplayName("Data Inicial das Aulas")]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [DisplayName("Data final das Aulas")]
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }

        [DisplayName("Turma")]
        [DataType(DataType.Date)]
        public int IDTurma { get; set; }
    }

}
