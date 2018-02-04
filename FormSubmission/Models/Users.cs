using System.ComponentModel.DataAnnotations;
 
namespace FormSubmission.Models
{
    public class Users
    {
        [Required]
        [Display(Name="First Name")]
        [MinLength(4, ErrorMessage = "Minimum is 4 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string first_name { get; set; }
        [Display(Name="Last Name")]
        [Required]
        [MinLength(4, ErrorMessage = "Minimum is 4 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string last_name { get; set; }

        [Display(Name="Age")]
        [Required]
        [Range(18,99)]
        public int age { get; set; }

        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length is 8 chars")]
        [DataType(DataType.Password)]
        public string password { get; set; }


        
    }
}
