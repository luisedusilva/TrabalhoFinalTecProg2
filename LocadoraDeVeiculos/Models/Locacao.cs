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
        [Display(Name = "Data de Locação")]
        public string DataLocacao { get; set; }
        [Required]
        [Display(Name = "Data de Devolução")]
        public string DataDevolucao { get; set; }
    }

}
