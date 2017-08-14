using System;
using System.ComponentModel.DataAnnotations;
using RESTauranter.CustomAttributes;

namespace RESTauranter.Models.ReviewViewModels {
    public class ReviewViewModel {


        [Required]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        [Display(Name = "Review")]
        public string ReviewText { get; set; }

        [Required]
        [PastDate(ErrorMessage = "Visit Date must be in the past")]
        [Display(Name = "Visit Date")]
        public DateTime VisitDate { get; set; }

    }


}
