using Data.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CompanyRepository : SQLRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDB dbContext;

        public CompanyRepository(ApplicationDB dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(Company company)
        {
            dbContext.Update(company);
            dbContext.SaveChanges();
        }
    }
}
