using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class SQLRepository<T> : IRepository<T> where T : class 
    {
        private readonly ApplicationDB dbContext;
        public readonly DbSet<T> dbSet;
        public SQLRepository(ApplicationDB dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);

        }

        public T Get(Expression<Func<T, bool>>? filter = null, string? includeproperties = null, bool tracked = false)
        {
            IQueryable<T> query;

            if (tracked)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.AsNoTracking();
            }
          
                query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var input in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(input);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null) query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeproperties))
            {
                foreach (var input in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(input);
                }
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
