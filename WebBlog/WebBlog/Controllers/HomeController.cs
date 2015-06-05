using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;
using PagedList;
using System.IO;
using System.Net;



namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {


        private LocalDBContext db = new LocalDBContext();

        // GET: Home
        public ActionResult Index(int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(db.Posts.ToList().OrderByDescending(e => e.CREATEDATE).ToList().ToPagedList(pageNumber, pageSize));
        }

       

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

    }
}