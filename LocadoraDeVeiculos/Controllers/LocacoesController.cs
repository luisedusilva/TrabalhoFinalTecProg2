using LocadoraDeVeiculos.Models;
using LocadoraDeVeiculos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos.Controllers
{
    public class LocacoesController : Controller
    {
        // GET: ValorLocacao
       

        public List<Locacao> Locacoes = new List<Locacao>
        {
            new Locacao {Id = 1, DataLocacao = "10/08/2017", DataDevolucao = "12/08/2017"},
            new Locacao {Id = 2, DataLocacao = "15/08/2017", DataDevolucao = "17/08/2017"}
        };


        // GET: Cliente
        public ActionResult Index()
        {

            var viewModel = new LocacaoIndexViewModel
            {
                Locacoes = Locacoes
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            if (Locacoes.Count < id)
            {
                return HttpNotFound();
            }

            var cliente = Locacoes[id - 1];

            return View(cliente);

        }
    }

}
