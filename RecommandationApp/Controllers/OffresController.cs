using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using RecommandationApp.Models;

namespace RecommandationApp.Controllers
{
    public class OffresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offres
        public ActionResult Index(string offreCat, string searchString)
        {
            var CatLst = new List<string>();

            var CatQry = from d in db.CategoryMs
                orderby d.Category
                select d.Category;

            CatLst.AddRange(CatQry);

            ViewBag.offreCat = new SelectList(CatLst);

            var offres = db.Offres.Include(o => o.Representant);
            
            if (!String.IsNullOrEmpty(searchString))
            {
                offres = offres.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(offreCat))
            {
                offres = offres.Where(x => x.CategoryM.Category == offreCat);
            }



            return View(offres.ToList());
        }

        // GET: Offres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
//            Include(c => c.Offre).Where();
            var comments = db.Comments.Include(c => c.Client).Where(c => c.Offre == id).ToList();       
            
            
            Offre offre = db.Offres.Find(id);
            var ratings = db.Ratings.Include(r => r.Offre).Where(r => r.Offre.Id == id).ToList();

            offre.Comments = comments;
            offre.Ratings = ratings;
//            offre.Comments = new List<Comment>();
            OffreViewModel offreViewModel = new OffreViewModel();
            offreViewModel.Offre = offre;
            offreViewModel.Comment = new Comment();
            

            if (offre == null)
            {
                return HttpNotFound();
            }

            return View(offreViewModel);
        }

        // GET: Offres/Create
        public ActionResult Create()
        {
            Offre e = new Offre();
            e.image = new byte[7000];
            ViewBag.IdRepresentant = new SelectList(db.Representants, "Id", "nom");
            var CatLst = new List<string>();
            var CatQry = from d in db.CategoryMs
                orderby d.Category
                select d.Category;
            CatLst.AddRange(CatQry);
            ViewBag.offreCat = new SelectList(CatLst);
            return View();
        }

        // POST: Offres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "Id,Title,Description,AdresseRecomo,TelRecomo,Image1,Image2,IdRepresentant")] Offre offre)
        public ActionResult Create(Offre offre)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        //                        System.IO.Directory.CreateDirectory("~/Images/");
                        var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                        offre.Image1 = fileName;
                        file.SaveAs(path);
                        using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                        {
                            
                            offre.image = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                        }

                    }
                    offre.IdRepresentant = User.Identity.GetUserId();
                    offre.IdCategoryM = 1;
                    db.Offres.Add(offre);
                        db.SaveChanges();
                        return RedirectToAction("Index");                    
                }
            } 
                ViewBag.IdRepresentant = new SelectList(db.Representants, "Id", "nom", offre.IdRepresentant);
                return View(offre);
            
        }
         
            // GET: Offres/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRepresentant = new SelectList(db.Representants, "Id", "nom", offre.IdRepresentant);
            return View(offre);
        }

        // POST: Offres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,AdresseRecomo,TelRecomo,Image1,Image2,IdRepresentant")] Offre offre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRepresentant = new SelectList(db.Representants, "Id", "nom", offre.IdRepresentant);
            return View(offre);
        }

        // GET: Offres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offre offre = db.Offres.Find(id);
            if (offre == null)
            {
                return HttpNotFound();
            }
            return View(offre);
        }

        // POST: Offres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Offre offre = db.Offres.Find(id);
            db.Offres.Remove(offre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "Id,Title,Description,AdresseRecomo,TelRecomo,Image1,Image2,IdRepresentant")] Offre offre)
        public ActionResult CreateComment(OffreViewModel offer)
        {
            string currentUserId = User.Identity.GetUserId();
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);
            //            comment.Comment.User = currentUser.Client;
            //            comment.Offre = 
            Comment com = new Comment();
            com.Client = currentUser.Client;
            com.Text = offer.Comment.Text;
            com.Offre = offer.Offre.Id;
            db.Comments.Add(com);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Rate(int? id, double rating)
        {
            /*
            var Users = db.Clients.ToList();
            var Offers = db.Offres.ToList();
//            string[] images = new string[] { "i1.jpg", "restaurant.jpg", "camp.jpg", "caf.jpg", "library.jpg1" };
            int k = 0;
            foreach (var user in Users)
            {
                if (k == 83) break;
                foreach(var of in Offers)
                {
                    Random rd = new Random();
                    int rInt = rd.Next(0, 3); //for ints
                    Rating rt = new Rating();
                    rt.value = rInt;
                    rt.Offre = of;
                    rt.Client = user;
                    db.Ratings.Add(rt);
                    db.SaveChanges();
                }
                k++;       
            }
            */
            Rating r = new Rating();
            r.value = rating;
            var offer = db.Offres.Find(id);                        
            int? idv = id;
            var ratings = db.Ratings.Include(rt => rt.Offre).Where(rt => rt.Offre.Id == id).ToList();
            offer.Ratings = ratings;
            offer.Ratings.Add(r);
            db.Entry(offer).State = EntityState.Modified;
            db.SaveChanges();
            //            return Content("rating offre id: " + offer.Title+ " is "+rating);
            return RedirectToAction("Details", new { id = idv });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
