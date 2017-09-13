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

        public List<Vendedor> Vendedores = new List<Vendedor>
        {
            new Vendedor {Id = 1, Nome = "José", Cadastro = 10533},
            new Vendedor {Id = 2, Nome = "João", Cadastro = 49578}
        };


        // GET: Cliente
        public ActionResult Index()
        {

            var viewModel = new VendedorIndexViewModel
            {
                Vendedores = Vendedores
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if (Vendedores.Count < id)
            {
                return HttpNotFound();
            }

            var cliente = Vendedores[id - 1];

            return View(cliente);

        }

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

            var vendedores = _context.Clientes.ToList();


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
    }
}

