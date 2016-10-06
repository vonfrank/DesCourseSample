using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Library
{
    public class DBService : IDBService
    {
        private IMongoDatabase database;

        public DBService() { }

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

        public void CreateCourse(Course course)
        {
            var collection = database.GetCollection<Course>("Course");

            collection.InsertOne(course);
        }

        public User GetUser(string id)
        {
            var collection = database.GetCollection<User>("User");

            return collection.Find(x => x.Id == new ObjectId(id)).Single();
        }

        public List<User> GetAllUser()
        {
            var collection = database.GetCollection<User>("User");

            return collection.Find(x => true).ToList();
        }

        public List<User> GetUserType(UserType usertype)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetUserCourse(string userid)
        {
            var collection = database.GetCollection<User>("User");

            return collection.Find(x => x.Id == new ObjectId(userid)).Single().Course.ToList();
        }

        public Course GetCourse(string id)
        {
            var collection = database.GetCollection<Course>("Course");

            return collection.Find(x => x.Id == new ObjectId(id)).Single();
        }

        public List<Course> GetAllCourse()
        {
            var collection = database.GetCollection<Course>("Course");

            return collection.Find(x => true).ToList();
        }

        public void SetUser(string id, User updateduser)
        {
            var collection = database.GetCollection<User>("User");
            var filter = Builders<User>.Filter.Eq(x => x.Id, new ObjectId(id));

            updateduser.Id = new ObjectId(id);

            collection.ReplaceOne(filter, updateduser);
        }

        public void SetCourse(string id, Course updatedcourse)
        {
            var collection = database.GetCollection<Course>("Course");
            var filter = Builders<Course>.Filter.Eq(x => x.Id, new ObjectId(id));

            updatedcourse.Id = new ObjectId(id);

            collection.ReplaceOne(filter, updatedcourse);
        }
        public void SignUpForCourse(string userid, string courseid)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCourse(string userid, string courseid)
        {
            throw new NotImplementedException();
        }
    }
}
