using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using MongoDB.Driver;

namespace Service
{
    public class DBService : IDBService
    {
        public static DBService instance;
        private IMongoDatabase database;

        public DBService() { }

        #region Singleton
        public static DBService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBService();
                }
                return instance;
            }
        }
        #endregion

        #region Connection
        public void SetConnection(string url, int port, string db, string username, string password)
        {
            var _client = new MongoClient(
                new MongoClientSettings
                {
                    Credentials = new[]
                    {
                        MongoCredential.CreateCredential(db, username, password)
                    },
                    Server = new MongoServerAddress(url, port)
                });
            database = _client.GetDatabase(db);
        }

        public void CloseConnection()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void CreateUser(User user)
        {
            var collection = database.GetCollection<User>("User");

            collection.InsertOne(user);
        }

        public List<Course> GetAllCourse()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetUserCourse(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserType(UserType usertype)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCourse(User user, Course course)
        {
            throw new NotImplementedException();
        }

        public void SetUser(User newuser, User olduser)
        {
            throw new NotImplementedException();
        }

        public void SignUpForCourse(User user, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
