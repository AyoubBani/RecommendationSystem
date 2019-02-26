using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RecommandationApp.Models;

namespace RecommandationApp.Controllers
{
    public class ProfilController : Controller
    {
        private ApplicationDbContext Mycontext;
//        private ApplicationUser currentUser;
//        private string currentUserId;
        public ProfilController()
        {
            Mycontext = new ApplicationDbContext();            
        }


        // GET: Profil
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = Mycontext.Users.FirstOrDefault(x => x.Id == currentUserId);

            return View(currentUser);
        }


        
    }
}