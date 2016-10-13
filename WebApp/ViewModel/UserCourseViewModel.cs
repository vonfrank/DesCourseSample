using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    public class UserCourseViewModel
    {
        public List<Course> allcourses { get; set; }
        public List<Course> usercourses { get; set; }
        public User user { get; set; }
    }
}