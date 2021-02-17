using BackEnd.Core.MongoService.Connection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.MongoService.Services
{
    public abstract class BaseMongoService<T> where T :BaseMongoModel
    {
        private string connectionString;
        private string dbName;
        private IMongoCollection<T> collection;

        protected BaseMongoService() { }
        protected BaseMongoService(string connectionString
            , string dbName)
        {
            this.dbName = dbName;
            this.connectionString = connectionString;

            this.GetCollection();
        }

        protected BaseMongoService(IMongoDbConnection mongoDbConnection)
        {
            this.dbName = mongoDbConnection.DatabaseName;
            this.connectionString = mongoDbConnection.ConnectionString;

            this.GetCollection();
        }

        private IMongoCollection<T> GetCollection()
        {
            var client = new MongoClient(this.connectionString);
            var database = client.GetDatabase(this.dbName);

            this.collection = database.GetCollection<T>(this.CollectionName);

            return this.collection;
        }

        protected abstract string CollectionName { get; }

        public IMongoCollection<T> Collection 
        {
            get { return this.collection; }
        }

        public List<T> GetAll()
        {
            return this.collection.Find(p => true).ToList(); 
        }

        public Task<List<T>> GetAllAsync()
        {
            return this.collection.Find(p => true).ToListAsync();
        }

        public T Get(string id)
        {
            return this.collection.Find<T>(p => p.Id == id).FirstOrDefault();
        }

        public Task<T> GetAsync(string id)
        {
            return this.collection.Find<T>(p => p.Id == id).FirstOrDefaultAsync();
        }

        public T Create(T t)
        {
            this.collection.InsertOne(t);
            return t;
        }

        public void Update(string id,T t)
        {
            this.collection.ReplaceOne(p => p.Id == id, t);
        }

        public void Remove(T t) =>
            this.collection.DeleteOne(p => p.Id == t.Id);

        public void Remove(string id) =>
            this.collection.DeleteOne(p => p.Id == id);
    }
}
