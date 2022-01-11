using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicatie.Models
{
    public class Message
    {
        [Key]
        public int Id {get; set;}
        public string naam {get; set;}
        public string text {get; set;}
        public DateTime currentTime {get; set;}

        public int ChatId {get; set;}

        public Chat chat {get; set;}
    }
}