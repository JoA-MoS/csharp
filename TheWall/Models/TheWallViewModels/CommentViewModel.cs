using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWall.Models.TheWallViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int MessageId { get; set; }
        [Required]
        [Display(Name = "Post a comment")]
        public string CommentText { get; set; }


    }
}
