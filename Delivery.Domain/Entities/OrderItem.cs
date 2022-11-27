using Delivery.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem() 
        {
        }

        public virtual Product Item { get; set; }

        public int Quantity { get; set; }

        public string Comments { get; set; }
    }
}
