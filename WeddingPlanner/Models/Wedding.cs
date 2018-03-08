using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int wedding_id {get; set;}

        public int creator {get; set;}

        [Display(Name="Wedder One")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string wedder_one {get; set;}

        [Display(Name="Wedder Two")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2, ErrorMessage = "Must be at least 2 characters!")]
        public string wedder_two {get; set;}

        [Display(Name = "Wedding Date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime wed_date {get; set;}

        [Display(Name="Address")]
        [Required]
        [MinLength(15, ErrorMessage = "Must be at least 15 characters!")]
        public string address {get; set;}
        public DateTime created_at {get; set;}
       
        public List<RSVP> rsvpGuests {get; set;}
        public Wedding()
        {
            created_at = DateTime.Now; 

        }
    }
}