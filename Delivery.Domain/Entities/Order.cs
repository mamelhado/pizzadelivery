using Delivery.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Order() 
        {
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Pedido consolidado
        /// </summary>
        public virtual IEnumerable<OrderItem> Itens { get; set; }

        /// <summary>
        /// Endereço de entrega
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Responsável para entrega
        /// </summary>
        public string Responsible { get; set; }


        /// <summary>
        /// Telefone para contato
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Data do cadastro do pedido
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Método de pagamento do pedido consolidado
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; }
    }
}
