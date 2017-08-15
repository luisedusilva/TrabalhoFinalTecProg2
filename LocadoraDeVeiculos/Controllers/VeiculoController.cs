using LocadoraDeVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class VeiculoController : Controller
    {
        // GET: Veiculo
        public ActionResult Index()
        {
            var veiculo = new Veiculo()
            {
                Id = 1,
                Ano = 2002,
                Marca = "Volkswagen",
                Modelo = "Gol",
                Placa = "MCD-2131",
                ValorDiaria = 50

            };
            return View(veiculo);
        }
    }
}