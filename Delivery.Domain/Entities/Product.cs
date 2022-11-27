using Delivery.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product() 
        {
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Nome da pizza, exemplo: Napolitana
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição dos ingredientes, exemplo: Mussarela, Manjericão, Tomate, Cebola, Orégano e Presunto
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data do cadastro do produto
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Preço do Produto
        /// </summary>
        public decimal Price { get; set; }
    }
}
