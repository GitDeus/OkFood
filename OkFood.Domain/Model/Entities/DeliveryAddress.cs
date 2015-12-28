using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Model.Entities
{
    public class DeliveryAddress
    {
        private Order _order;
        public Guid DeliveryAdressId { get; set; }
        public string City{ get; set; }

        /*район*/
        public string District { get; set; }
        /*улица*/
        public string Street { get; set; }
        /*дом*/
        public string House { get; set; }
        /*корпус*/
        public string Housing { get; set; }
        /*номер */
        public int Number { get; set; }

        public string Comment { get; set; }

        public Guid OrderId { get; set; }

        #region Navigation Properties
        public Order Order
        {
            get { return _order; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _order = value;
                OrderId = value.OrderId;
            }
        }
        #endregion
    }
}
