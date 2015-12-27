using OkFood.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order FindId(Guid Id);
        IList<Order> AllOrderByUser(Guid UserId);
        int OrderCount(Guid OrderId);

    }
}
