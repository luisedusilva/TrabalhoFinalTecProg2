using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocadoraDeVeiculos.Models;

namespace LocadoraDeVeiculos.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = new Cliente()
            {
                Id = 1,
                CPF = "123.456.789-00",
                Idade = 18,
                Nome = "José"

            };
            return View(cliente);
        }
    }
}