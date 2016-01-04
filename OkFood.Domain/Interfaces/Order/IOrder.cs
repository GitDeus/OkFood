using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkFood.Domain.Interfaces.Order
{
    public interface IOrder<out Guid>
    {
        Guid OrderId { get; }
        string Title { get; set; }
    }
}
