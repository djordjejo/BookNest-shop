using Data.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderDetailRepository : SQLRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDB dbContext;

        public OrderDetailRepository(ApplicationDB dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Update(OrderDetail orderDetail)
        {
            dbContext.Update(orderDetail);
        }
    }
}
