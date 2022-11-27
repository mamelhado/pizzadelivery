using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Delivery.Domain.Entities.Audit
{
    public class EntityAudit
    {
        [NotMapped]
        public int Id { get; set; }

        [NotMapped]
        public EntityState State { get; set; }

        [NotMapped]
        public string AuditMessage { get; set; }

        [NotMapped]
        public SaveChangesAudit SaveChangesAudit { get; set; }
    }
}
