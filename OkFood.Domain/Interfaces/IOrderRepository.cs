using OkFood.Domain.Interfaces;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IList<Order> AllOrderByUser(Guid UserId);
        Order FindId(Guid orderId);
        int OrderCount(Guid OrderId);

    }
}
