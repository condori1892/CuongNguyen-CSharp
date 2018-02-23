using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace theWall.Models
{
    public class User
    {
        [Required(ErrorMessage = "Please enter the user's first name.")]
        [Display(Name="First Name")]
        [MinLength(2, ErrorMessage = "Minimum is 2 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string first_name { get; set; }
        
        [Display(Name="Last Name")]
        [Required(ErrorMessage = "Please enter the user's last name.")]
        [MinLength(2, ErrorMessage = "Minimum is 2 chars")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        public string last_name { get; set; }

        [Display(Name="Email")]
        [Required(ErrorMessage = "Please enter the user's email.")]
        [EmailAddress(ErrorMessage = "The Email Address is not valid")]
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
    public class LogUser
    {
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string log_email { get; set; }

        [Display(Name="Password")]
        [Required]
        [MinLength(8, ErrorMessage = "Minimum length is 8 chars")]
        [DataType(DataType.Password)]
        public string log_password { get; set; }

    }

    public class Comment
    {
        [Display(Name="Comment")]
        [Required]
        [MinLength(15, ErrorMessage="Mininum length is 15 chars")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string comment { get; set;}
        public int users_id {get;set;}

        public int messages_id {get;set;}
    }

    public class Message
    {

        [Display(Name="Message")]
        [Required]
        [MinLength(15, ErrorMessage="Mininum length is 15 chars")]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        public string message { get; set;}
        public int users_id {get;set;}

    }
}