using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace LoadOnDemandSQL2016.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

  

     [WebMethod]
     public ActionResult GetItems(int PageNumber)
        {
            LoadOnDemandSQL2016.Models.Items m = new LoadOnDemandSQL2016.Models.Items(PageNumber);
            return PartialView("/Views/Home/_GetItems.cshtml", m );
        }


    }
}