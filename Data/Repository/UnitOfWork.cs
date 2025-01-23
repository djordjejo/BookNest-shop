using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository categoryRepository { get; private set; }
        public UnitOfWork(ApplicationDB dbContext)
        {
            categoryRepository = new CategoryRepository(dbContext);
        }
    }
}
