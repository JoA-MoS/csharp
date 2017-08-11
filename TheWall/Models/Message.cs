using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Message : AuditEntity
    {
        public int MessageId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Column(TypeName = "text")]
        public string MessageText { get; set; }
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
