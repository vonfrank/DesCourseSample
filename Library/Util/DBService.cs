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
        public bool SetConnection(string url, int port, string db, string username, string password)
        {
            try
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

                return true;
            }
            catch
            {
                //TODO: Error handling
                return false;
            }
            
        }

        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }
        #endregion

        public void CreateUser(User user)
        {
            try
            {
                var _collection = database.GetCollection<User>("User");

                _collection.InsertOne(user);
            }
            catch
            {
                //TODO: Error handling
            }
        }

        public void CreateCourse(Course course)
        {
            try
            {
                var _collection = database.GetCollection<Course>("Course");

                _collection.InsertOne(course);
            }
            catch
            {
                //TODO: Error handling
            }
        }

        public User GetUser(string id)
        {
            var _collection = database.GetCollection<User>("User");

            return _collection.Find(x => x.Id == new ObjectId(id)).Single();
        }

        public List<User> GetAllUser()
        {
            try
            {
                var _collection = database.GetCollection<User>("User");

                return _collection.Find(x => true).ToList();
            }
            catch
            {
                //TODO: Error handling

                return null;
            }
        }

        public List<User> GetUserType(UserType usertype)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetUserCourse(string userid)
        {
            try
            {
                var _collection = database.GetCollection<User>("User");
                List<ObjectId> _courseidlist = _collection.Find(x => x.Id == new ObjectId(userid)).Single().Course.ToList();
                List<Course> _courselist = new List<Course>();

                foreach (ObjectId oid in _courseidlist)
                {
                    _courselist.Add(GetCourse(oid.ToString()));
                }

                return _courselist;
            }
            catch
            {
                //TODO: Error handling

                return null;
            }
        }

        public List<User> GetCourseUser(string courseid)
        {
            try
            {
                var _collection = database.GetCollection<Course>("Course");
                List<ObjectId> _useridlist = _collection.Find(x => x.Id == new ObjectId(courseid)).Single().User.ToList();
                List<User> _userlist = new List<User>();

                foreach (ObjectId oid in _useridlist)
                {
                    _userlist.Add(GetUser(oid.ToString()));
                }

                return _userlist;
            }
            catch
            {
                //TODO: Error handling

                return null;
            }
        }

        public Course GetCourse(string id)
        {
            try
            {
                var _collection = database.GetCollection<Course>("Course");

                return _collection.Find(x => x.Id == new ObjectId(id)).Single();
            }
            catch
            {
                //TODO: Error handling

                return null;
            }

            
        }

        public List<Course> GetAllCourse()
        {
            try
            {
                var _collection = database.GetCollection<Course>("Course");

                return _collection.Find(x => true).ToList();
            }
            catch
            {
                //TODO: Error handling

                return null;
            }
        }

        public void SetUser(string id, User updateduser)
        {
            var _collection = database.GetCollection<User>("User");
            var _filter = Builders<User>.Filter.Eq(x => x.Id, new ObjectId(id));

            updateduser.Id = new ObjectId(id);

            _collection.ReplaceOne(_filter, updateduser);
        }

        public void SetCourse(string id, Course updatedcourse)
        {
            var _collection = database.GetCollection<Course>("Course");
            var _filter = Builders<Course>.Filter.Eq(x => x.Id, new ObjectId(id));

            updatedcourse.Id = new ObjectId(id);

            _collection.ReplaceOne(_filter, updatedcourse);
        }

        public void DeleteUser(string id)
        {
            var _collection = database.GetCollection<User>("User");
            var _filter = Builders<User>.Filter.Eq(x => x.Id, new ObjectId(id));

            foreach(Course c in GetAllCourse())
            {
                if(c.User.Contains(new ObjectId(id)))
                {
                    Course _tempcourse = c;
                    _tempcourse.User.Remove(new ObjectId(id));
                    SetCourse(c.Id.ToString(), _tempcourse);
                }
            }

            _collection.DeleteOne(_filter);
        }

        public void DeleteCourse(string id)
        {
            var _collection = database.GetCollection<Course>("Course");
            var _filter = Builders<Course>.Filter.Eq(x => x.Id, new ObjectId(id));

            foreach(User u in GetAllUser())
            {
                if(u.Course.Contains(new ObjectId(id)))
                {
                    User _tempuser = u;
                    _tempuser.Course.Remove(new ObjectId(id));
                    SetUser(u.Id.ToString(), _tempuser);
                }
            }

            _collection.DeleteOne(_filter);
        }
        public void SignUpForCourse(string userid, string courseid)
        {
            User _tempuser = GetUser(userid);
            Course _tempcourse = GetCourse(courseid);
            if(!_tempuser.Course.Contains(new ObjectId(courseid)) && !_tempcourse.User.Contains(new ObjectId(userid)))
            {
                _tempuser.Course.Add(GetCourse(courseid).Id);
                _tempcourse.User.Add(GetUser(userid).Id);

                SetUser(userid, _tempuser);
                SetCourse(courseid, _tempcourse);
            }
        }

        public void RemoveFromCourse(string userid, string courseid)
        {
            User _tempuser = GetUser(userid);
            Course _tempcourse = GetCourse(courseid);
            if(_tempuser.Course.Contains(new ObjectId(courseid)) && _tempcourse.User.Contains(new ObjectId(userid)))
            {
                _tempuser.Course.Remove(GetCourse(courseid).Id);
                _tempcourse.User.Remove(GetUser(userid).Id);

                SetUser(userid, _tempuser);
                SetCourse(courseid, _tempcourse);
            }
        }
    }
}
