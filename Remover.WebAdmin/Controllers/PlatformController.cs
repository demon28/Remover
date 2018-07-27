using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Controllers;
using Remover.DataAccess;

namespace Remover.WebAdmin.Controllers
{
    public class PlatformController : TopControllerBase
    {
        // GET: Platform
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPlatform()
        {
            string KeyWord = Request.Params["KeyWord"].ToString();
            Tmp_PlatformCollection tCollection = new Tmp_PlatformCollection();
            tCollection.ChangePage = this.ChangePage();
            tCollection.ListByKeyWord(KeyWord);
            return SuccessResultList(tCollection);
        }

    }
}