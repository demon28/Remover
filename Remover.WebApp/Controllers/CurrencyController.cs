using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Remover.Entities;
using static Remover.Entities.EnumType;
using Remover.Facade;
using Winner.Framework.MVC.Controllers;
using Remover.DataAccess;

namespace Remover.WebApp.Controllers
{
    public class CurrencyController : TopControllerBase
    {
        // GET: Currency
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult ListCurrency()
        {
            Tr_QuotesCollection quotes = new Tr_QuotesCollection();
            quotes.ListByCurrents();


            return SuccessResult();
        }
    }
}