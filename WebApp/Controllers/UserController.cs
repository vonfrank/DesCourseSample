using Library;
using Library.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Facade;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private ServiceFacade sf;

        public UserController()
        {
            sf = new ServiceFacade(new DBService());
        }

        // GET: User
        public ActionResult Index()
        {
            return View(sf.GetAllUser());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(user.Password);
                data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
                user.Password = System.Text.Encoding.ASCII.GetString(data);

                sf.CreateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            return View(sf.GetUser(id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, User updateduser)
        {
            try
            {
                sf.SetUser(id, updateduser);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult UserCourses(string id)
        {
            UserCourseViewModel _viewmodel = new UserCourseViewModel();
            _viewmodel.allcourses = sf.GetAllCourse();
            _viewmodel.usercourses = sf.GetUserCourse(id);
            _viewmodel.user = sf.GetUser(id);

            return View(_viewmodel);
        }

        public ActionResult UserCoursesAdd(string userid, string courseid)
        {
            sf.SignUpForCourse(userid, courseid);

            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
