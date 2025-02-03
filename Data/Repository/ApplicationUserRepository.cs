using Data.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ApplicationUserRepository : SQLRepository<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDB dbContext;

        public ApplicationUserRepository(ApplicationDB dbContext) : base (dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(ApplicationUser applicationUser)
        {
            throw new NotImplementedException();
        }
    }
}
