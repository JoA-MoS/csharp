using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheWall.Models.TheWallViewModels
{
    public class MessageViewModel
    {
        [Required]
        [Display(Name = "Post a message")]
        public string MessageText { get; set; }


    }
}
