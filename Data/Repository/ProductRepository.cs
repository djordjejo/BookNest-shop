using Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProductRepository : SQLRepository<Product>, IProductRepository
    {
        private readonly ApplicationDB applicationDB;

        public ProductRepository(ApplicationDB applicationDB) : base(applicationDB)
        {
            this.applicationDB = applicationDB;
        }
        public void Update(Product product)
        {
            applicationDB.Update(product);
        }
    }
}
