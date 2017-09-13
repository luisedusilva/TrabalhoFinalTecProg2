using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Models
{
    public class Locacao
    {
        public int Id { get; set; }
        public Veiculo Veiculo { get; set; }
        public string DataLocacao { get; set; }
        public string DataDevolucao { get; set; }
    }

}
