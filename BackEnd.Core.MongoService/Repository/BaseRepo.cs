using BackEnd.Core.Model.Repository;
using BackEnd.Core.MongoService.Services;
using Model = BackEnd.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Core.MongoService.Converter;
using System.Threading.Tasks;
using BackEnd.Core.MongoService.Connection;

namespace BackEnd.Core.MongoService.Repository
{
    public abstract class BaseRepo<TM,T> : IGenericGetRepo<T>
        where TM : BaseMongoModel
        where T : class
    {
        protected BaseMongoService<TM> service;
        protected BaseConverter<T, TM> converter;
        protected IMongoDbConnection mongoDbConnection;

        protected BaseRepo() { }
        protected BaseRepo(BaseMongoService<TM> service
            , BaseConverter<T,TM> converter) 
        {
            this.converter = converter;
            this.service = service;
        }

        protected BaseRepo(IMongoDbConnection mongoDbConnection)
        {
            this.mongoDbConnection = mongoDbConnection;
        }

        protected abstract TM getById(string id);

        public T GetById(string id)
        {
            return this.converter.Convert(this.getById(id));
        }

        protected abstract TM getById(int id);

        public T GetById(int id)
        {
            return this.converter.Convert(this.getById(id));
        }

        protected abstract List<TM> getByName(string name);

        public List<T> GetByName(string name)
        {
            List<T> result = new List<T>();
            foreach(var item in this.getByName(name))
            {
                result.Add(this.converter.Convert(item));
            }
            return result;
        }

        public Task<List<T>> GetByNameAsync(string name)
        {
            return Task.Run<List<T>>(() =>
            {
                return this.GetByName(name);
            });
        }

        protected abstract List<TM> get();

        public List<T> Get()
        {
            List<T> list = new List<T>();
            foreach (var item in this.get())
            {
                list.Add(this.converter.Convert(item));
            }
            return list;
        }

        protected abstract Task<TM> getByIdAsync(string id);

        public Task<T> GetByIdAsync(string id)
        {
            return Task.Run<T>(() =>
            {
                return this.converter.Convert(this.service.Get(id));
            });
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
