using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;

namespace LocadoraDeVeiculos.Controllers
{
    public class ClientesController : Controller
    {
        public List<Cliente> Clientes = new List<Cliente>
        {
            new Cliente {Nome = "Luis", Id = 1, CPF = "123.456.789-00", Idade = 18},
            new Cliente {Nome = "João", Id = 2, CPF = "987.654.321-32", Idade = 60}
        };


        // GET: Cliente
        public ActionResult Index()
        {

            var viewModel = new ClienteIndexViewModel
            {
                Clientes = Clientes
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if (Clientes.Count < id)
            {
                return HttpNotFound();
            }

            var cliente = Clientes[id - 1];

            return View(cliente);

        }
    }
}