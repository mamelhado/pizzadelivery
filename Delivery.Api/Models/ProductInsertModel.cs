namespace Delivery.Api.Models
{
    public class ProductInsertModel : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
