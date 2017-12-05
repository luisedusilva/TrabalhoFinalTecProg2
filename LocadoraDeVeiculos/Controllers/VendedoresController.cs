using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    [Authorize]
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
        [Authorize]
        public ActionResult Index()
        {
            var vendedores = _context.Vendedores.ToList();
            if (User.IsInRole("StoreAdmin"))
                return View(vendedores);
            return View("ReadOnlyIndex", vendedores);
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Details(int id)
        {
            var vendedor = _context.Vendedores.SingleOrDefault(c => c.Id == id);

            if (vendedor == null)
            {
                return HttpNotFound();
            }

            return View(vendedor);

        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult New()
        {

            var vendedor = new Vendedor();

            return View("VendedorForm", vendedor);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Save(Vendedor vendedor) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {


                return View("VendedorForm", vendedor);
            }
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
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Edit(int id)
        {
            var vendedor = _context.Vendedores.SingleOrDefault(c => c.Id == id);

            if (vendedor == null)
                return HttpNotFound();


            return View("VendedorForm", vendedor);
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Delete(int id)
        {
            var vendedor = _context.Vendedores.SingleOrDefault(c => c.Id == id);

            if (vendedor == null)
                return HttpNotFound();

            _context.Vendedores.Remove(vendedor);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}

