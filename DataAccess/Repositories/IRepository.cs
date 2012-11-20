using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> GetAll();
        bool Save(T entity);
        bool Delete(Guid id);
        bool Delete(T entity);
    }
}
