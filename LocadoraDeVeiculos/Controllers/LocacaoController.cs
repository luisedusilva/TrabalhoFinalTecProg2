using LocadoraDeVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class LocacaoController : Controller
    {
        // GET: ValorLocacao
        public ActionResult Index()
        {
            var locacao = new Locacao()
            {
                DataLocacao = "15/08/2017",
                DataDevolucao = "20/08/2017",
                Id = 1,

            };
            return View(locacao);
        }
    }
}