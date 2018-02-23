using System;
using System.Collections.Generic;

namespace theWall.Models
{
    public class AllClasses
    {
        public User newUser { get; set;}
        public LogUser loginUser { get; set;}
        public Comment newComment { get; set;}
        public Message newMessage { get; set;}

        public List<Dictionary<string,object>> allMessages {get; set;}
        public List<Dictionary<string,object>> allComments {get; set;}

    }
}