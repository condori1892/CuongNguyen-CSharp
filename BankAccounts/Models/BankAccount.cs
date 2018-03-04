using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Account
    {
        [Key]
        public int account_id {get; set;}

        [Display(Name="Current Balance")]
        public float balance {get; set;}

        // [RegularExpression(@"^-?(0|[1-9]\d*)(?<!-0)$", ErrorMessage = "Only Number")]
        // [RegularExpression(@"^[0-9]\d{0,9}(\.\d{1,2})?%?$", ErrorMessage = "Only Number")]
        // [Required]
        public float activity {get; set;}

        public DateTime activity_date {get; set;}

        public int user_id {get; set;}

        public User AccountUser {get; set;}

        public Account()
        {
            activity_date = DateTime.Now;
        }


    }
    // public class TransAction : Account
    // {
    //     [RegularExpression(@"^-?(0|[1-9]\d*)(?<!-0)$", ErrorMessage = "Only Number")]
    //     [Required]
    //     public string inputAmount {get; set;}
    // }
}