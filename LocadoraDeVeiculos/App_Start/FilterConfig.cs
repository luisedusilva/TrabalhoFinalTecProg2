﻿using System.Web;
using System.Web.Mvc;

namespace LocadoraDeVeiculos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Adicionamos o filtro authorize
            // para toda a aplicação
            filters.Add(new AuthorizeAttribute());
        }
    }
}
