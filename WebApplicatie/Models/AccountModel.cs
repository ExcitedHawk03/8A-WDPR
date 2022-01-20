
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApplicatie.Models;

public class Account : IdentityUser{
     public Account() : base()
        {
            Chats = new List<ChatUser>();
        }
    public string Tussenvoegsel {get; set;}
    [Required(ErrorMessage = "Achternaam is verplicht")]
    public string Achternaam {get; set;}
    [Required(ErrorMessage = "Leeftijd is verplicht")]
    public int Leeftijd {get; set;}
    public string Geslacht {get; set;}
    [Required(ErrorMessage = "Email is verplicht")]
    
    public string Telnr {get; set;}
    [Required(ErrorMessage = "Adres is verplicht")]
    public string Adres {get; set;}
    [Required(ErrorMessage = "Postcode is verplicht")]
    public string Postcode {get; set;}
    [Required(ErrorMessage = "Plaats is verplicht")]
    public string Plaats {get; set;}

    public string Voornaam {get; set;}
    public string typAccount {get; set;}

    public virtual List<ChatUser> Chats {get; set;}

    public bool blocked {get; set;}

    public string aangemeldeHulpverlener {get; set;}

}

public class hulpverlener : Account {

    public hulpverlener () : base(){
        cliënten = new List<client>();
    }
  public List<client> cliënten {get; set;} 
   public int chatNummer {get; set;}

}


 public class ouder : Account{

     public client kinderen {get; set;}

}

 public class client: Account {
     public string ouderId {get; set;}
     public ouder ouder {get; set;}
    
     public hulpverlener hulpverlener {get; set;}     

     public int messageFrequency {get; set;}  
}
