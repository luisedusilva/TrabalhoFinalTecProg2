using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class VeiculosController : Controller
    {
        // GET: Veiculo


        private ApplicationDbContext _context;

        public List<Veiculo> Veiculos = new List<Veiculo>
        {
            new Veiculo {Id = 1, Marca = "Fiat", Modelo = "Uno", Ano = 2000, Placa = "ABC-123", ValorDiaria = 90},
            new Veiculo {Id = 2, Marca = "Chevrolet", Modelo = "Corsa", Ano = 2005, Placa = "DEF-456", ValorDiaria = 85}
        };


        // GET: Cliente
        public ActionResult Index()
        {

            var viewModel = new VeiculoIndexViewModel
            {
                Veiculos = Veiculos
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if (Veiculos.Count < id)
            {
                return HttpNotFound();
            }

            var cliente = Veiculos[id - 1];

            return View(cliente);

        }

        public VeiculosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Cliente
        public ActionResult Index()
        {

            var veiculos = _context.Veiculos.ToList();


            return View(veiculos);
        }

        public ActionResult Details(int id)
        {
            var veiculo = _context.Veiculos.ToList();

            if (veiculo == null)
            {
                return HttpNotFound();
            }

            return View(veiculo);

        }
    }
}


