using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace RESTauranter.Models
{
    public class Restaurant : AuditEntity
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public virtual List<Review> Reviews { get; set; } = new List<Review>();

    }
}
