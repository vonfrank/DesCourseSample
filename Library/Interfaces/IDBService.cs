using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IDBService
    {
        bool SetConnection(string url, int port, string db, string username, string password);
        bool CloseConnection();
        void CreateUser(User user);
        void CreateCourse(Course course);
        User GetUser(string id);
        List<User> GetAllUser();
        List<User> GetUserType(UserType usertype);
        List<Course> GetUserCourse(string userid);
        List<User> GetCourseUser(string courseid);
        Course GetCourse(string id);
        List<Course> GetAllCourse();
        void SetUser(string id, User updateduser);
        void SetCourse(string id, Course updatedcourse);
        void DeleteUser(string id);
        void DeleteCourse(string id);
        void SignUpForCourse(string userid, string courseid);
        void RemoveFromCourse(string userid, string courseid);
    }
}
