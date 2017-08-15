using LocadoraDeVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor
        public ActionResult Index()
        {
            var vendedor = new Vendedor()
            {
                Cadastro = 123,
                Id = 1,
                Nome = "Luis"
            };
            return View(vendedor);
        }
    }
}