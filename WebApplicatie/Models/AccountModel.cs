
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
   public List<cliënt> cliënten {get; set;} 
   public int chatNummer {get; set;}

   public hulpverlener(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password, int chatnummer){
       voorNaam = voornaam;
       tussenVoegsel = tussenvoegsel;
       achterNaam = achternaam;
       gebruikersNaam = gebruikersnaam;
       wachtwoord = password;
       typAccount = "hulpvelener";
       chatNummer = chatnummer;
   }

}


public class ouder : Account{
    
    public List<cliënt> kinderen {get; set;}

    public ouder(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password){
       voorNaam = voornaam;
       tussenVoegsel = tussenvoegsel;
       achterNaam = achternaam;
       gebruikersNaam = gebruikersnaam;
       wachtwoord = password;
       typAccount = "ouder";
       
   }
}

public class cliënt: Account {
    public ouder ouder {get; set;}
    [Required]
    public hulpverlener hulpverlener {get; set;}

    public cliënt(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password, hulpverlener doktor){
       voorNaam = voornaam;
       tussenVoegsel = tussenvoegsel;
       achterNaam = achternaam;
       gebruikersNaam = gebruikersnaam;
       wachtwoord = password;
       typAccount = "cliënt";
       hulpverlener = doktor;
       
   }

}

public class moderator: Account{

    public moderator(string voornaam, string tussenvoegsel, string achternaam, string gebruikersnaam, string password){
       voorNaam = voornaam;
       tussenVoegsel = tussenvoegsel;
       achterNaam = achternaam;
       gebruikersNaam = gebruikersnaam;
       wachtwoord = password;
       typAccount = "moderator";
       
   }
}
