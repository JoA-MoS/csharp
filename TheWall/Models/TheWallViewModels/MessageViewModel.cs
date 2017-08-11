using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWall.Models.AccountViewModels
{
    public class MessageViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "You must enter a message", MinimumLength = 1)]
        [Display(Name = "Post a message")]
        public string MessageText { get; set; }


    }
}
