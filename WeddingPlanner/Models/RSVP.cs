using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class RSVP
    {
        [Key]
        public int rsvp_id {get; set;}
        public int wedding_id {get; set;}
        public Wedding rsvpWedding {get; set;}

        public int user_id {get; set;}
        public User rsvpGuest {get; set;}
        public DateTime created_at {get; set;}
        public DateTime updated_at {get; set;}

        public RSVP()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }


    }
}