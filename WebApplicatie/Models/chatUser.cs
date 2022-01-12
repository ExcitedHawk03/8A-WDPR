namespace WebApplicatie.Models{

    public class ChatUser
    {
        public string AccountId {get; set;}
        public Account account {get; set;}

        public int ChatId {get; set;}
        public Chat chat {get; set;}
    }
}