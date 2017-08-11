using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Comment : AuditEntity
    {
        public int CommentId { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        [Column(TypeName = "text")]
        public string CommentText { get; set; }
    }
}
