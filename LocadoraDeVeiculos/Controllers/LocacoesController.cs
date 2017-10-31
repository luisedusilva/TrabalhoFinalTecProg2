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
        private ApplicationDbContext _context;



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
            var locacao = _context.Locacoes.ToList();

            if (locacao == null)
            {
                return HttpNotFound();
            }

            return View(locacao);

        }

        public ActionResult New()
        {

            var locacao = new Locacao();

            return View("LocacaoForm", locacao);
        }

        [HttpPost] // só será acessada com POST
        public ActionResult Save(Locacao locacao) // recebemos um cliente
        {
            if (locacao.Id == 0)
            {
                // armazena o cliente em memória
                _context.Locacoes.Add(locacao);
            }
            else
            {
                var customerInDb = _context.Locacoes.Single(c => c.Id == locacao.Id);

                customerInDb.DataLocacao = locacao.DataLocacao;
                customerInDb.DataDevolucao = locacao.DataDevolucao;             
                customerInDb.Veiculo = locacao.Veiculo;

            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var locacao = _context.Locacoes.SingleOrDefault(c => c.Id == id);

            if (locacao == null)
                return HttpNotFound();


            return View("LocacaoForm", locacao);
        }
    }
}
