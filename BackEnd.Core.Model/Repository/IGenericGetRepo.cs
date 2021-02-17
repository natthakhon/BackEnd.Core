using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.Model.Repository
{
    public interface IGenericGetRepo<T>
    {
        T GetById(string id);
        T GetById(int id);
        List<T> GetByName(string name);
        List<T> Get();
        Task<T> GetByIdAsync(string id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetByNameAsync(string name);
        Task<List<T>> GetAsync();
    }
}
