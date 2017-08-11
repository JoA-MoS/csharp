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
        [StringLength(100, ErrorMessage = "You must enter a comment", MinimumLength = 1)]
        [Display(Name = "Post a comment")]
        public string CommentText { get; set; }


    }
}
