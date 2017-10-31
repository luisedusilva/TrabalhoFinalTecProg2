using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Marca")]
        public string Marca { get; set; }
        [Required]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        [Required]
        [Display(Name = "Placa")]
        public string Placa { get; set; }
        [Required]
        [Display(Name = "Ano")]
        public int Ano { get; set; }
        [Required]
        [Display(Name = "Valor Diária")]
        public double ValorDiaria { get; set; }
    }
}