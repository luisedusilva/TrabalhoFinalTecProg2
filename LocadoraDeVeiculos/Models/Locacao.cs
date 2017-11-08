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
        [Required]
        [Display(Name = "Veiculo")]
        public Veiculo Veiculo { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public Cliente Cliente { get; set; }
        [Required]
        [Display(Name = "Vendedor")]
        public Vendedor Vendedor { get; set; }
        [Required]
        [Display(Name = "Data de Locação")]
        public string DataLocacao { get; set; }


    }

}
