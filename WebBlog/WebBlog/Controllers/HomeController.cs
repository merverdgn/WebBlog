using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {

        private LocalDBContext db = new LocalDBContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

    }
}