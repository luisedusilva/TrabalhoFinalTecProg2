using LocadoraDeVeiculos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDeVeiculos.ViewModels
{
    public class LocacaoIndexViewModel
    {
        public List<Veiculo> Veiculos { get; set; }
        public List<Vendedor> Vendedores { get; set; }
        public List<Cliente> Clientes { get; set; }

        public Locacao Locacao { get; set; }

    }
}