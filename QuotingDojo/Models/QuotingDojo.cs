using System.ComponentModel.DataAnnotations;

namespace QuotingDojo.Models
{
    public class Quote
    {
        
        // [Display(Name="Your Name")]
        // [Required]
        // [MinLength(2, ErrorMessage = "Minimum is 4 chars")]
        // [MinLength(5, ErrorMessage = "Must be at least 5 characters!")]
        // public string name {get;set;}

        // [Display(Name="Your Quote")]
        // [Required]
        // [MinLength(15, ErrorMessage = "Must be at least 15 characters!")]
        // public string quote {get;set;}

        [Required]
        [Display(Name="Your Name")]
        [MinLength(3, ErrorMessage = "Minimum is 4 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string name { get; set; }
        
        [Display(Name="Your Quote")]
        [Required]
        [MinLength(15, ErrorMessage = "Minimum is 4 chars")]
        [MaxLength(500)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string quote { get; set; }
    }
}