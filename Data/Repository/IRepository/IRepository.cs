using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.IRepository
{
    public interface IRepository<T> 
    {
        public T Get(Expression<Func<T, bool>>? filter = null, string? includeproperties = null);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string includeproperties = null);
        public void Remove(T entity);
        public void Add(T entity);
    }
}
