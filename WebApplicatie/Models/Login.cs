using System.ComponentModel.DataAnnotations;

public class Login
{
    [Key]
    public int Id {get; set;}
    [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
    public string Gebruikersnaam {get; set;}
    [Required(ErrorMessage = "Wachtwoord is verplicht")]
    public string Wachtwoord {get; set;}
   
}