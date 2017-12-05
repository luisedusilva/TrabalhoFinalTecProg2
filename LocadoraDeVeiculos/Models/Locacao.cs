using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Models
{
    public class Locacao
    {
        public int Id { get; set; }

        [Display(Name = "Veiculo")]
        public Veiculo Veiculo { get; set; }
        public int VeiculoId { get; set; }

        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        [Display(Name = "Vendedor")]
        public Vendedor Vendedor { get; set; }
        public int VendedorId { get; set; }

        [Display(Name = "Data de Locação")]
        public string DataLocacao { get; set; }
    }

}
