using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;
using PagedList;
using System.IO;



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

        [HttpPost]
        public ActionResult Upload()
        {
            string directory = HttpContext.Server.MapPath("~/Content/img/");

            HttpPostedFileBase photo = Request.Files["photo"];

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);
                photo.SaveAs(Path.Combine(directory, fileName));
            }

            return RedirectToAction("Index");
        }

    }
}