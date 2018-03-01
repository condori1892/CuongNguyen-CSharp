using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestReview
{
    public class Review
    {
        [Key]
        public int review_id {get; set;}


        [Display(Name = "Review")]
        [Required]
        [MinLength(15, ErrorMessage = "Must be at least 15 characters!")]
        public string content {get; set;}

        [Display(Name = "Restaurant Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string rest_name {get; set;}

        [Display(Name = "Reivewer Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string reviewer_name {get; set;}

        [Display(Name = "Rating")]
        [Required]
        public int rating {get; set;}

        [Display(Name = "Date of Visit")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime visited_date {get; set;}
    }
}