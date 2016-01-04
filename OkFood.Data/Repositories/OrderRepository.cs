using OkFood.Data.Context;
using OkFood.Data.Model.Interfaces;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Repositories
{
    internal class OrderRepository:Repository<Order>, IOrderRepository
    {
        internal OrderRepository(DataContext context)
            : base(context)
        {
        }

         public IList<Order> AllOrderByUser(Guid UserId)
        {
            return Set.Where(x => x.User.UserId == UserId).ToList();
        }

        public Order FindId(Guid Id)
        {
           return Set.FirstOrDefault(x=>x.OrderId == Id);
        }

        public int OrderCount(Guid OrderId)
        {
            var res = Set.Select(x => x);
            return res.Count();
        }
    }
}
