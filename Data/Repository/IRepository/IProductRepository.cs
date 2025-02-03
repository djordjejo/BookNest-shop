using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.IRepository
{
   public interface IProductRepository : IRepository<Product>
   {
        public void Update(Product entity);

    }
}
