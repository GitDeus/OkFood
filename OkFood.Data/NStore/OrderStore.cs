using OkFood.Domain.Interfaces;
using OkFood.Domain.Interfaces.Order;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.NStore 
{

    public interface IOrderStore<TOrder, in Guid> : IDisposable where TOrder : class, IOrder<Guid>
    {
        IList<Order> AllOrderByUser(Guid UserId);
        int OrderCount(Guid OrderId);

        Task CreateAsync(Order order, Guid userId);
        Task DeleteAsync(Order order);
        Task<Order> FindByIdAsync(Guid orderId);
        Task UpdateAsync(Order order);

    }
    public class OrderStore : IOrderStore<Order, Guid>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public OrderStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task CreateAsync(Order order, Guid userId)
        {
            if (order == null)
                throw new ArgumentNullException("order");
            var user = _unitOfWork.UserRepository.FindById(userId);

            if (user == null)
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            var or = new Order
            {
                OrderId = Guid.NewGuid(),
                Title = order.Title,
                DeliveryAddressId = order.DeliveryAddressId,
            };
            user.Orders.Add(or);

            _unitOfWork.UserRepository.Update(user);
            return _unitOfWork.SaveChangesAsync();
        }

        public IList<Order> AllOrderByUser(Guid UserId)
        {
            return _unitOfWork.OrderRepository.AllOrderByUser(UserId);
        }

        public int OrderCount(Guid OrderId)
        {
            var res = _unitOfWork.OrderRepository.OrderCount(OrderId);
            return res;
        }

        public Task DeleteAsync(Order order)
        {
           if (order == null)
                throw new ArgumentNullException("order");

            _unitOfWork.OrderRepository.Remove(order);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<Order> FindByIdAsync(Guid orderId)
        {
            return _unitOfWork.OrderRepository.FindByIdAsync(orderId);
        }
        public Task UpdateAsync(Order order)
        {
            if (order == null)
                throw new ArgumentException("order");

            _unitOfWork.OrderRepository.Update(order);
            return _unitOfWork.SaveChangesAsync();
        }
    }
}
