using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTauranter.Models
{
    public class Review : AuditEntity
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime VisitDate { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}
