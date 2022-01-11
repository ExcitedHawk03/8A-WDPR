using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicatie.Models
{

    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
        }
        [Key]
        public int Id {get; set;}
        public ICollection<Message> Messages {get; set;}

        public chatRuimte ruimte {get; set;}
        public string naam {get; set;}

        
    }
}