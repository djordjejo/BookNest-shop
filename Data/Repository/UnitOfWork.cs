using Data.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        public IRepository<Category> categoryRepository { get; private set; }
        public UnitOfWork()
        {
            categoryRepository = new Reoosito
        }
    }
}
