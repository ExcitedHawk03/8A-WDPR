using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicatie.Models
{

    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
            Users = new List<ChatUser>();
        }
        [Key]
        public int Id {get; set;}
        public ICollection<Message> Messages {get; set;}

        public chatRuimte ruimte {get; set;}
        public string naam {get; set;}

        public virtual ICollection<ChatUser> Users {get; set;}

        public int ageGroup {get; set;}

        
    }
}