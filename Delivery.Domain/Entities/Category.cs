using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category() 
        {
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Nome de uma categoria de produtos, exemplos: Pizzas, Bebidas
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição da categoria, exemplo: Categorizar os tipos dos produtos 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data do cadastro do produto
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Coleção de subcategorias, exemplo: Se esta categoria for Pizza, as subcategorias poderão ser Tradicional, Vegana ou Vegetariana
        /// </summary>
        public virtual IEnumerable<SubCategory> SubCategory { get; set; }
    }
}
