using OkFood.Data.Model.Interfaces;
using OkFood.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkFood.Domain.Model.Entities;
using System.Threading;

namespace OkFood.Service
{
    public interface IOrderService
    {
        void Add(Order order, Guid UserId);
        void Remove(Order order);
        Order FindId(Guid Id);
        IList<Order> All();
        int OrderCount(Guid OrderId);
    }
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }
        public void Add(Order order, Guid UserId)
        {
            if (order == null)
                throw new ArgumentNullException("order");

            var user = userRepository.FindById(UserId);
            if (user == null)
                throw new ArgumentException("IdentityUser не соответствуют сущности пользователя.", "user");

            var c = new Order
            {
                OrderId = order.OrderId,
                Title = order.Title
            };

            //user.TotalMoney -= c.NumberofMoney;
            user.Orders.Add(c);
           
            userRepository.Update(user);
            Save();

            /*ОБРАТИТЬ ВНИМАНИЕ**/
        }

        public IList<Order> All()
        {
            return orderRepository.GetAll();
      
        }

        public Order FindById(object id)
        {
            return orderRepository.FindById(id);
        }

        public Order FindId(Guid Id)
        {
            return orderRepository.FindById(Id);
        }

        public List<Order> GetAll()
        {
            return orderRepository.GetAll();
        }

        public void Remove(Order entity)
        {
            orderRepository.Remove(entity);
            Save();
        }

        public void Update(Order entity)
        {
            orderRepository.Update(entity);
            Save();
        }
        public int OrderCount(Guid OrderId)
        {
            return orderRepository.OrderCount(OrderId);
        }









        public Task<Order> FindByIdAsync(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> FindByIdAsync(CancellationToken cancellationToken, object id)
        {
            throw new NotImplementedException();
        }
        public Task<List<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public List<Order> PageAll(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> PageAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> PageAllAsync(CancellationToken cancellationToken, int skip, int take)
        {
            throw new NotImplementedException();
        }


    }
}
