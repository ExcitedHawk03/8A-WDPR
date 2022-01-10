
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

public class Account{
     [Key]
    public int ID {get; set;}
    [Required]
    public string voorNaam {get; set;}
    public string tussenVoegsel {get; set;}
    [Required]
    public string achterNaam {get; set;}

    public string gebruikersNaam {get; set;}
    public string wachtwoord {get; set;}

    public string typAccount {get; set;}

}

public class hulpverlener : Account {
  public List<client> cliënten {get; set;} 
   public int chatNummer {get; set;}

//    public hulpverlener(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password, int chatnummer){
//        voorNaam = voornaam;
//        tussenVoegsel = tussenvoegsel;
//        achterNaam = achternaam;
//        gebruikersNaam = gebruikersnaam;
//        wachtwoord = password;
//        typAccount = "hulpvelener";
//        chatNummer = chatnummer;
//    }

}


 public class ouder : Account{
    
     public List<client> kinderen {get; set;}

    // public ouder(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password){
    //    this.voorNaam = voornaam;
    //    tussenVoegsel = tussenvoegsel;
    //    achterNaam = achternaam;
    //    gebruikersNaam = gebruikersnaam;
    //    wachtwoord = password;
    //    typAccount = "ouder";
       
    // }
}

 public class client: Account {
     public ouder ouder {get; set;}
    
     public hulpverlener hulpverlener {get; set;}

//     public client(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password){
//        voorNaam = voornaam;
//        tussenVoegsel = tussenvoegsel;
//        achterNaam = achternaam;
//        gebruikersNaam = gebruikersnaam;
//        wachtwoord = password;
//        typAccount = "cliënt";
      
       
    }

// }

 public class moderator: Account{

//     public moderator(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password){
//        voorNaam = voornaam;
//        tussenVoegsel = tussenvoegsel;
//        achterNaam = achternaam;
//        gebruikersNaam = gebruikersnaam;
//        wachtwoord = password;
//        typAccount = "moderator";
       
   }
// }
