using Library;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Facade
{
    public class ServiceFacade
    {
        private IDBService dbservice;

        public ServiceFacade(IDBService idbservice)
        {
            this.dbservice = idbservice;

            if(!dbservice.SetConnection("185.15.73.124", 27017, "descoursesystem", "desuser", "vonfrankisawesome") == true)
            {
                //Do error stuff
            }
        }

        public void CreateUser(User user)
        {
            dbservice.CreateUser(user);
        }

        public void CreateCourse(Course course)
        {
            dbservice.CreateCourse(course);
        }

        public User GetUser(string id)
        {
            return dbservice.GetUser(id);
        }

        public List<User> GetAllUser()
        {
            return dbservice.GetAllUser();
        }

        public List<User> GetUserType(UserType usertype)
        {
            return dbservice.GetUserType(usertype);
        }

        public List<Course> GetUserCourse(string userid)
        {
            return dbservice.GetUserCourse(userid);
        }

        public List<User> GetCourseUser(string courseid)
        {
            return dbservice.GetCourseUser(courseid);
        }

        public Course GetCourse(string id)
        {
            return dbservice.GetCourse(id);
        }

        public List<Course> GetAllCourse()
        {
            return dbservice.GetAllCourse();
        }

        public void SetUser(string id, User updateduser)
        {
            dbservice.SetUser(id, updateduser);
        }

        public void SetCourse(string id, Course updatedcourse)
        {
            dbservice.SetCourse(id, updatedcourse);
        }

        public void DeleteUser(string id)
        {
            dbservice.DeleteUser(id);
        }

        public void DeleteCourse(string id)
        {
            dbservice.DeleteCourse(id);
        }

        public void SignUpForCourse(string userid, string courseid)
        {
            dbservice.SignUpForCourse(userid, courseid);
        }

        public void RemoveFromCourse(string userid, string courseid)
        {
            dbservice.RemoveFromCourse(userid, courseid);
        }
    }
}