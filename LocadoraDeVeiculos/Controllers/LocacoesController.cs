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
            var locacoes = _context.Locacoes.Include(a => a.Veiculo).Include(a => a.Cliente).Include(a => a.Vendedor).ToList();
            return View(locacoes);

        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Details(int id)
        {
            var locacao = _context.Locacoes.Include(a => a.Veiculo).Include(a => a.Cliente).Include(a => a.Vendedor).SingleOrDefault(a => a.Id == id);

            if (locacao == null)
            {
                return HttpNotFound();
            }

            return View(locacao);

        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult New()
        {

            var locacao = new LocacaoIndexViewModel
            {
                Locacao = new Locacao(),
                Veiculos = _context.Veiculos.ToList(),
                Clientes = _context.Clientes.ToList(),
                Vendedores = _context.Vendedores.ToList(),
            };

            return View("LocacaoForm", locacao);
        }

        [HttpPost] // só será acessada com POST
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Save(Locacao locacao) // recebemos um cliente
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new LocacaoIndexViewModel
                {
                    Locacao = locacao,
                    Veiculos = _context.Veiculos.ToList(),
                    Clientes = _context.Clientes.ToList(),
                    Vendedores = _context.Vendedores.ToList()

                };
                return View("LocacaoForm", viewModel);
            }

            if (locacao.Id == 0)
            {
                // armazena o cliente em memória
                _context.Locacoes.Add(locacao);
            }
            else
            {
                var locacaoInDb = _context.Locacoes.Single(c => c.Id == locacao.Id);

                locacaoInDb.DataLocacao = locacao.DataLocacao;
                locacaoInDb.Veiculo = locacao.Veiculo;

            }

            // faz a persistência
            _context.SaveChanges();
            // Voltamos para a lista de clientes
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Edit(int id)
        {
            var locacao = _context.Locacoes.SingleOrDefault(c => c.Id == id);

            if (locacao == null)
                return HttpNotFound();

            var viewModel = new LocacaoIndexViewModel
            {
                Locacao = locacao,
                Veiculos = _context.Veiculos.ToList(),
                Clientes = _context.Clientes.ToList(),
                Vendedores = _context.Vendedores.ToList(),

            };


            return View("LocacaoForm", viewModel);
        }
        [Authorize(Roles = "StoreAdmin")]
        public ActionResult Delete(int id)
        {
            var locacao = _context.Locacoes.SingleOrDefault(c => c.Id == id);

            if (locacao == null)
                return HttpNotFound();

            _context.Locacoes.Remove(locacao);
            _context.SaveChanges();

            return new HttpStatusCodeResult(200);
        }
    }
}
