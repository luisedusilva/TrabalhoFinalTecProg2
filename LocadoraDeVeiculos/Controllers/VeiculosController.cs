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


        private ApplicationDbContext _context;



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
            var veiculo = _context.Veiculos.SingleOrDefault(c => c.Id == id);

            if (veiculo == null)
            {
                return HttpNotFound();
            }

            return View(veiculo);

        }

        public ActionResult New()
        {

            var veiculo = new Veiculo();

            return View("VeiculoForm", veiculo);
        }

        [HttpPost] // só será acessada com POST
        public ActionResult Save(Veiculo veiculo) // recebemos um cliente
        {
            if (veiculo.Id == 0)
            {
                // armazena o cliente em memória
                _context.Veiculos.Add(veiculo);
            }
            else
            {
                var customerInDb = _context.Veiculos.Single(c => c.Id == veiculo.Id);

                customerInDb.Marca = veiculo.Marca;
                customerInDb.Modelo = veiculo.Modelo;
                customerInDb.Placa = veiculo.Placa;
                customerInDb.ValorDiaria = veiculo.ValorDiaria;
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var veiculo = _context.Veiculos.SingleOrDefault(c => c.Id == id);

            if (veiculo == null)
                return HttpNotFound();


            return View("VeiculoForm", veiculo);
        }
    }
}


