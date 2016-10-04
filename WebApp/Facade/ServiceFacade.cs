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
            dbservice.SetConnection("185.15.73.124", 27017, "descoursesystem", "desuser", "vonfrankisawesome");
        }

        public List<User> GetAllUser()
        {
            return dbservice.GetAllUser();
        }

        public User GetUser(string id)
        {
            return dbservice.GetUser(id);
        }

        public void CreateUser(User user)
        {
            dbservice.CreateUser(user);
        }

        public void SetUser(User user)
        {
            dbservice.SetUser(user);
        }
    }
}