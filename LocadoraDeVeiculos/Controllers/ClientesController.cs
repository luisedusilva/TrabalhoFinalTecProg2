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
    public class ClientesController : Controller
    {

        private ApplicationDbContext _context;

        public List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente {Nome = "Luis", Id = 1, CPF = "123.456.789-00", Idade = 18},
            new Cliente {Nome = "João", Id = 2, CPF = "987.654.321-32", Idade = 60}
        };

        public ClientesController()
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

            var clientes = _context.Clientes.ToList();


            return View(clientes);
        }

        public ActionResult Details(int id)
        {
            var cliente = _context.Clientes.ToList();

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);

        }
    }
}