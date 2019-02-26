using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecommandationApp.Models;

namespace RecommandationApp.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Clients()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Representants()
        {
            return View();
        }
    }
}