using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ViewModel
{
    public class UserCourseViewModel
    {
        public List<User> allusers { get; set; }
        public List<Course> allcourses { get; set; }
        public List<Course> usercourses { get; set; }
        public List<User> courseusers { get; set; }
        public User user { get; set; }
        public Course course { get; set; }
    }
}