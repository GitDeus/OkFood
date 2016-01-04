using OkFood.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Interfaces
{
    public interface IDeliveryAddressRepository: IRepository<DeliveryAddress>
    {
        List<DeliveryAddress> AllDeliveryAddressByUserId(Guid UserId);
        DeliveryAddress Get(Guid DeliveryAddressId);
    }
}
