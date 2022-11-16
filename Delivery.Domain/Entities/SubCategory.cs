using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public SubCategory() 
        {
            this.CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Nome da sub categoria, exemplo: Se a categoria for Pizza, as subcategorias poderiam ser Tradicional, Vegana ou Vegetariana
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição da subcategoria, exemplo: Subcategoria de pizzas veganas
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data do cadastro da subcategoria
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Chave que relaciona esta subcategoria com uma categoria
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Objeto categoria relacionado a esta subcategoria
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
