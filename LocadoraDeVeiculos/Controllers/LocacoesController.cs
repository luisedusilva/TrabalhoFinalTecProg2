using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LocadoraDeVeiculos.Controllers
{
    public class LocacoesController : Controller
    {
        // GET: ValorLocacao

        private ApplicationDbContext _context;

        public List<Locacao> Locacoes = new List<Locacao>
        {
            new Locacao {Id = 1, DataLocacao = "10/08/2017", DataDevolucao = "12/08/2017"},
            new Locacao {Id = 2, DataLocacao = "15/08/2017", DataDevolucao = "17/08/2017"}
        };


        // GET: Cliente
        public LocacoesController()
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

            var locacoes = _context.Locacoes.ToList();


            return View(locacoes);
        }

        public ActionResult Details(int id)
        {
            var locacao = _context.Clientes.ToList();

            if (locacao == null)
            {
                return HttpNotFound();
            }

            return View(locacao);

        }

    }
}
