using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Data.Model.Entities
{
    public class Order
    {
        private ICollection<DeliveryAddress> _deliveryAddress;
        private User _user;
        public Guid OrderId { get; set; }
        public string Title { get; set; }

        public Guid UserId { get; set; }
        public User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("valueuser");
                _user = value;
            }
        }
        public Guid DeliveryAddressId { get; set; }
        public ICollection<DeliveryAddress> DeliveryAddress
        {
            get { return _deliveryAddress ?? (_deliveryAddress = new List<DeliveryAddress>()); }
            set { _deliveryAddress = value; }
        }
    }
}
