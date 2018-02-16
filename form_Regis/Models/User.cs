using System.ComponentModel.DataAnnotations;
 
namespace form_Regis.Models
{
    public class User
    {
        [Required]
        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage = "Minimum is 4 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string first_name { get; set; }
        
        [Display(Name="Last Name")]
        [Required]
        [MinLength(2, ErrorMessage = "Minimum is 4 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string last_name { get; set; }

        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length is 8 chars")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Password Confirmation")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password and confirmation must match.")]
        public string passwordConfirmation { get; set; }

        
    }
    public class Quote
    {
        
        [Display(Name= "Your Name")]
        [Required]
        // [MinLength(2, ErrorMessage = "Minimum is 4 chars")]
        [MinLength(5, ErrorMessage = "Must be at least 5 characters!")]
        public string name { get; set; }

        [Display(Name= "Your Quote")]
        [Required]
        [MinLength(15, ErrorMessage = "Must be at least 15 characters!")]
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string quote { get; set; }
    }
}
