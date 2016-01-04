using OkFood.Data.Model.Interfaces;
using OkFood.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OkFood.Domain.Model.Entities;
using System.Threading;

namespace OkFood.BLL
{

    public class OrderService : IOrderRepository
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }

        public void Add(Order entity)
        {
            orderRepository.Add(entity);
            Save();
        }

        public IList<Order> AllOrderByUser(Guid UserId)
        {
            return orderRepository.AllOrderByUser(UserId);
      
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
