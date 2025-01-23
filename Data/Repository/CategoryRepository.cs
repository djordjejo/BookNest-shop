using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Models;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CategoryRepository : SQLRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDB dbContext;

        public CategoryRepository(ApplicationDB dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(Category category)
        {
            dbContext.Update(category);
            dbContext.SaveChanges();
        }
    }
}
