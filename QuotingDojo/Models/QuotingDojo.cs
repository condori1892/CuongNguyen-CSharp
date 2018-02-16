using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace QuotingDojo.Models
{
    public class Quote
    {
        
        [Display(Name="Your Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string name {get;set;}

        [Display(Name="Your Quote")]
        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        [MinLength(15, ErrorMessage = "Must be at least 15 characters!")]
        public string quote {get;set;}
        
        

        // [Required]
        // [Display(Name="Your Name")]
        // [MinLength(3, ErrorMessage = "Minimum is 4 chars")]
        // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        // public string name { get; set; }
        
        // [Display(Name="Your Quote")]
        // [Required]
        // [MinLength(15, ErrorMessage = "Minimum is 4 chars")]
        // [MaxLength(500)]
        // [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        // public string quote { get; set; }
        // public List<string> Validation()
        // {
        //     List<string> error = new List<string>();
        //     if(name.Length == 0)
        //         error.Add("Name field is required!");
        //     if(name.Length < 2)
        //         error.Add("Name must be at least 2 chars!");
        //     if(quote.Length == 0)
        //         error.Add("Your Quote field is required!");
        //     if(quote.Length < 0)
        //         error.Add("Your Quote must be at least 15 chars!");
        //     return error;
        // }
        
    }
   
    
}