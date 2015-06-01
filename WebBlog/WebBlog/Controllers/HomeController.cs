using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;
using PagedList;



namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {


        private LocalDBContext db = new LocalDBContext();

        // GET: Home
        public ActionResult Index(int? page)
        {
           
            int pageSize = 3;
            int pageNumber = (page ?? 1);            
         
            return View(db.Posts.ToList().OrderByDescending(e => e.CREATEDATE).ToList().ToPagedList(pageNumber, pageSize));
        }

    }
}