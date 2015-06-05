using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class PostPicsController : Controller
    {
        private LocalDBContext db = new LocalDBContext();

        // GET: PostPics
        public ActionResult Index()
        {
            return View(db.PostPics.ToList());
        }

        // GET: PostPics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostPic postPic = db.PostPics.Find(id);
            if (postPic == null)
            {
                return HttpNotFound();
            }
            return View(postPic);
        }

        // GET: PostPics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostPics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,URL,AUTHOR,UPDATE")] PostPic postPic)
        {
            if (ModelState.IsValid)
            {
                db.PostPics.Add(postPic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postPic);
        }

        // GET: PostPics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostPic postPic = db.PostPics.Find(id);
            if (postPic == null)
            {
                return HttpNotFound();
            }
            return View(postPic);
        }

        // POST: PostPics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,URL,AUTHOR,UPDATE")] PostPic postPic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postPic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postPic);
        }

        // GET: PostPics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostPic postPic = db.PostPics.Find(id);
            if (postPic == null)
            {
                return HttpNotFound();
            }
            return View(postPic);
        }

        // POST: PostPics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostPic postPic = db.PostPics.Find(id);
            db.PostPics.Remove(postPic);
            db.SaveChanges();
            return RedirectToAction("Index");
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
