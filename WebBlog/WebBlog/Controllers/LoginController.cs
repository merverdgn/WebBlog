using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBlog.Models;

namespace WebBlog.Controllers
{
    public class LoginController : Controller
    {

        private LocalDBContext db = new LocalDBContext();


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        // GET: Verify Users
        public ActionResult VerifyLogin()
        {

            return View();

        }


        // POST : Verify Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerifyLogin([Bind(Include = "ID,FIRSTNAME,LASTNAME,USERNAME,PASSWORD,EMAIL")] User user)
        {

            ViewBag.Status = "Oturum açma işlemi başarılı.";

            //The ".FirstOrDefault()" method will return either the first matched
            //result or null
            var myUser = db.Users
                .FirstOrDefault(u => u.USERNAME == user.USERNAME
                             && u.PASSWORD == user.PASSWORD);

            if (myUser != null)    //User was found
            {

                Session["USERNAME"] = user.USERNAME.ToString();

                return RedirectToAction("../Home/Index");


            }
            else
            {

                ViewBag.Status = "Oturum açma işlemi başarısız.";

            }


            return View();

        }


        public ActionResult Logout() {

            Session.Abandon();

            return RedirectToAction("../Home/Index");
        
        }

    }
}