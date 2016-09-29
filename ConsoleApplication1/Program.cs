using Library.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DBService dbs = new DBService();
            dbs.SetConnection("185.15.73.124", 27017, "descoursesystem", "desuser", "vonfrankisawesome");
            User user = new User();
            user.FirstName = "Mads";
            user.LastName = "Riisom";
            user.Email = "marii13@student.sdu.dk";
            user.UserType = UserType.Administrator;

            dbs.CreateUser(user);
        }
    }
}
