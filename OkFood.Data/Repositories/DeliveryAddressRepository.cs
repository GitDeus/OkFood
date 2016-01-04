using OkFood.Data.Context;
using OkFood.Domain.Interfaces;
using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Repositories
{
    internal class DeliveryAddressRepository: Repository<DeliveryAddress>, IDeliveryAddressRepository
    {
        internal DeliveryAddressRepository(DataContext context)
            : base(context)
        {
        }

        public List<DeliveryAddress> AllDeliveryAddressByUserId(Guid UserId)
        {
            return Set.Where(s=>s.User.UserId == UserId).ToList();/*dfvdfvdvdfvdfvdfvdvdf*/
        }

        public DeliveryAddress Get(Guid DeliveryAddressId)
        {
            return Set.FirstOrDefault(s => s.DeliveryAdressId == DeliveryAddressId);
        }
    }
}
