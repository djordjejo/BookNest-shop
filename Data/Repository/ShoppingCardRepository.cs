using Data.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data.Repository
{
   public class ShoppingCardRepository : SQLRepository<ShoppingCard>, IShoppingCardRepository
    {
        private readonly ApplicationDB dbContext;

        public ShoppingCardRepository(ApplicationDB dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    
        public void Update(ShoppingCard shopping)
        {
            dbContext.Update(shopping);
            
        }
      
    }
}
