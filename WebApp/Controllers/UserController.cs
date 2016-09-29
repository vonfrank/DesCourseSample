using Library.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private DBService dbs;
        // GET: User
        public ActionResult Index()
        {
            dbs = new DBService();
            dbs.SetConnection("185.15.73.124", 27017, "descoursesystem", "desuser", "vonfrankisawesome");

            return View(dbs.GetAllUser());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}