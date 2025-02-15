using Data.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderHeaderRepository : SQLRepository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDB dbContext;

        public OrderHeaderRepository(ApplicationDB dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(OrderHeader orderHeader)
        {
            dbContext.Update(orderHeader);
        }
    }
}
