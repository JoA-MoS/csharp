using System;


namespace TheWall.Models
{
    public abstract class AuditEntity : BaseEntity
    {
        public DateTime Created { get; set; } = DateTime.UtcNow;
        // public ApplicationUser CreateBy { get; set; }
        public DateTime Modified { get; set; } = DateTime.UtcNow;
        // public ApplicationUser ModifiedBy { get; set; }
    }
}
