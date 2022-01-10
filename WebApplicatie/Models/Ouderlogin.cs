using System.ComponentModel.DataAnnotations;

public class Ouderlogin
{
    [Key]
    public int Id2 {get; set;}
    [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
    public string Oudergebruikersnaam {get; set;}
    [Required(ErrorMessage = "Wachtwoord is verplicht")]
    public string Ouderwachtwoord {get; set;}
   
}