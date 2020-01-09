using Campeonato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campeonato.Domain.Interfaces
{
    public interface IRepository<T> where T: Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(long id);
    }
}
