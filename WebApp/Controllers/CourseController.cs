﻿using Library;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Facade;
using WebApp.ViewModel;

namespace WebApp.Controllers
{
    public class CourseController : Controller
    {
        private ServiceFacade sf;

        public CourseController()
        {
            sf = new ServiceFacade(new DBService());
        }

        // GET: Course
        public ActionResult Index()
        {
            return View(sf.GetAllCourse());
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                sf.CreateCourse(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(string id)
        {
            return View(sf.GetCourse(id));
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Course updatedcourse)
        {
            try
            {
                sf.SetCourse(id, updatedcourse);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CourseUsers(string id)
        {
            UserCourseViewModel _viewmodel = new UserCourseViewModel();
            _viewmodel.courseusers = sf.GetCourseUser(id);
            _viewmodel.course = sf.GetCourse(id);

            return View(_viewmodel);
        }

        public ActionResult CourseUsersRemove(string userid, string courseid)
        {
            sf.RemoveFromCourse(userid, courseid);

            return RedirectToAction("Index");
        }

        // GET: Course/Delete/5
        public ActionResult Delete(string id)
        {
            sf.DeleteCourse(id);

            return RedirectToAction("Index");
        }
    }
}
