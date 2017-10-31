using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class VendedoresController : Controller
    {
        // GET: Vendedor

        private ApplicationDbContext _context;



        public VendedoresController()
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

            var vendedores = _context.Vendedores.ToList();


            return View(vendedores);
        }

        public ActionResult Details(int id)
        {
            var vendedor = _context.Vendedores.ToList();

            if (vendedor == null)
            {
                return HttpNotFound();
            }

            return View(vendedor);

        }

        public ActionResult New()
        {

            var vendedor = new Vendedor();

            return View("VendedorForm", vendedor);
        }

        [HttpPost] // só será acessada com POST
        public ActionResult Save(Vendedor vendedor) // recebemos um cliente
        {
            if (vendedor.Id == 0)
            {
                // armazena o cliente em memória
                _context.Vendedores.Add(vendedor);
            }
            else
            {
                var customerInDb = _context.Vendedores.Single(c => c.Id == vendedor.Id);

                customerInDb.Cadastro = vendedor.Cadastro;
                customerInDb.Nome = vendedor.Nome;

            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var vendedor = _context.Vendedores.SingleOrDefault(c => c.Id == id);

            if (vendedor == null)
                return HttpNotFound();


            return View("VeiculoForm", vendedor);
        }
    }
}

