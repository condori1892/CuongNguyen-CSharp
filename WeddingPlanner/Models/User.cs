using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int user_id {get; set;}
        
        [Display(Name="First Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string first_name {get; set;}

        [Display(Name="Last Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string last_name {get; set;}

        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string email {get; set;}

        [Display(Name="Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
        public string password {get; set;}

        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}

        public List<RSVP> rsvpWeddings {get; set;}

        // public List<Account> transaction {get; set;}

        public User()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;

        }
    }

    public class NewUser : User
    {
        [Display(Name = "Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password and Confirm Password must match.")]
        public string pw_confirm { get; set; }
    }

    public class LoginUser
    {
        [Display(Name="Email")]
        [Required]
        [EmailAddress]
        public string logEmail {get; set;}

        [Display(Name="Password")]
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters!")]
        public string logPassword {get; set;}

    }
}