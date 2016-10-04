using Library;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            DBService dbs = new DBService();

            dbs.SetConnection("185.15.73.124", 27017, "descoursesystem", "desuser", "vonfrankisawesome");

            User user = dbs.GetUser("57f26082d3441a36a80abd5c");

            Console.WriteLine(user.FirstName);
            Console.WriteLine(user.Id.ToString());
            Console.ReadLine();
        }
    }
}
