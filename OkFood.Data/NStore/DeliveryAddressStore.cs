using OkFood.Domain.Interfaces;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.NStore
{
    public interface IDeliveryAddressStore<TDeliveryAddress, in Guid> : IDisposable where TDeliveryAddress : class
    {
        IList<DeliveryAddress> AllDeliveryAddressByUserId(Guid UserId);
        IList<DeliveryAddress> All();
        Task<DeliveryAddress> Get(Guid DeliveryAddressId);


        Task CreateAsync(DeliveryAddress delivery, Guid userId);
        Task DeleteAsync(DeliveryAddress delivery);
        Task UpdateAsync(DeliveryAddress delivery);
        int Count(Guid userId);

    }
    public class DeliveryAddressStore: IDeliveryAddressStore<DeliveryAddress, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeliveryAddressStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<DeliveryAddress> All()
        {
            return _unitOfWork.DeliveryAddressRepository.GetAll();
        }

        public IList<DeliveryAddress> AllDeliveryAddressByUserId(Guid UserId)
        {
            return _unitOfWork.DeliveryAddressRepository.AllDeliveryAddressByUserId(UserId);
        }

        public int Count(Guid userId)
        {
            return _unitOfWork.DeliveryAddressRepository.AllDeliveryAddressByUserId(userId).Count();
        }

        public Task CreateAsync(DeliveryAddress delivery, Guid userId)
        {
            if (delivery == null)
                throw new ArgumentNullException("delivery");
            else if (Count(userId) > 5)
                throw new ArgumentNullException("The Count exceeds 5");
            
            var user = _unitOfWork.UserRepository.FindById(userId);

            //if (order == null)
            //    throw new ArgumentException("order null", "order");

            var del = new DeliveryAddress
            {
              City = delivery.City,
              UserId = userId,
              Comment = delivery.Comment,
              District = delivery.District,
              House = delivery.House,
              Housing = delivery.Housing,
              Number = delivery.Number,
              Street = delivery.Street,
              DeliveryAdressId = Guid.NewGuid()
              
            };
            user.AllDeliveryAdress.Add(del);
            _unitOfWork.UserRepository.Update(user);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task DeleteAsync(DeliveryAddress delivery)
        {
            if (delivery == null)
                throw new ArgumentNullException("delivery");

            var d = _unitOfWork.DeliveryAddressRepository.FindById(delivery.DeliveryAdressId);

            var l = d.User.AllDeliveryAdress.FirstOrDefault(x => x.DeliveryAdressId == delivery.DeliveryAdressId);
            d.User.AllDeliveryAdress.Remove(l);

            _unitOfWork.DeliveryAddressRepository.Update(d);
            return _unitOfWork.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<DeliveryAddress> Get(Guid DeliveryAddressId)
        {
            if (DeliveryAddressId == null)
                throw new ArgumentNullException("DeliveryAddressId");

            var delivery = default(DeliveryAddress);

            var l = _unitOfWork.DeliveryAddressRepository.Get(DeliveryAddressId);

            return Task.FromResult<DeliveryAddress>(delivery);
        }

        public Task UpdateAsync(DeliveryAddress delivery)
        {
            if (delivery == null)
                throw new ArgumentException("delivery");

            _unitOfWork.DeliveryAddressRepository.Update(delivery);
            return _unitOfWork.SaveChangesAsync();
        }

    }
}
