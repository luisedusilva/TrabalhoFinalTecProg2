using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;
using System.Data.Entity;

namespace LocadoraDeVeiculos.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {

        private ApplicationDbContext _context;

        

        public ClientesController()
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
            var clientes = _context.Clientes.ToList();
            if (User.IsInRole("StoreAdmin"))
                return View(clientes);
            return View("ReadOnlyIndex", clientes);
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Details(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);

        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult New()
        {
           
            var cliente = new Cliente();

            return View("ClienteForm", cliente);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Save(Cliente cliente) // recebemos um cliente
        {
            if (!ModelState.IsValid)
            {
      

                return View("ClienteForm", cliente);
            }

            if (cliente.Id == 0)
            {
                // armazena o cliente em memória
                _context.Clientes.Add(cliente);
            }
            else
            {
                var customerInDb = _context.Clientes.Single(c => c.Id == cliente.Id);

                customerInDb.Nome = cliente.Nome;
                customerInDb.CPF = cliente.CPF;
                customerInDb.Idade = cliente.Idade;
                
            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Edit(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();


            return View("ClienteForm", cliente);
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return HttpNotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}