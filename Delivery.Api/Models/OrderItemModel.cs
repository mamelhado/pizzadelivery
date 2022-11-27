namespace Delivery.Api.Models
{
    public class OrderItemModel : BaseModel
    {
        public virtual ProductInsertModel Item { get; set; }

        public int Quantity { get; set; }

        public string Comments { get; set; }
    }
}
