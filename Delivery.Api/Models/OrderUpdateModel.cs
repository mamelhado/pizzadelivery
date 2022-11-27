using Delivery.Api.Models.Enum;

namespace Delivery.Api.Models
{
    public class OrderUpdateModel : BaseModel
    {
        public IEnumerable<OrderItemModel> Itens { get; set; }

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
        public PaymentMethodModel PaymentMethod { get; set; }
    }
}
