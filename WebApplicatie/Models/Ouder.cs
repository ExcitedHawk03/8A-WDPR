using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Ouder
{
    [Key]
    public int Id {get; set;}
    [Required(ErrorMessage = "Voornaam is verplicht")]
    public string Voornaam {get; set;}
    public string Tussenvoegsel {get; set;}
    [Required(ErrorMessage = "Achternaam is verplicht")]
    public string Achternaam {get; set;}
    [Required(ErrorMessage = "Leeftijd is verplicht")]
    public int Leeftijd {get; set;}
    public string Geslacht {get; set;}
    [Required(ErrorMessage = "Email is verplicht")]

    public string Email {get; set;}
    public string Telnr {get; set;}
    [Required(ErrorMessage = "Adres is verplicht")]
    public string Adres {get; set;}
    [Required(ErrorMessage = "Postcode is verplicht")]
    public string Postcode {get; set;}
    [Required(ErrorMessage = "Plaats is verplicht")]
    public string Plaats {get; set;}

    [Required(ErrorMessage = "De voornaam van uw kind is verplicht")]
    public string Voornaam_kind {get; set;}
    public string Tussenvoegsel_kind {get; set;}
    [Required(ErrorMessage = "De achternaam van uw kind is verplicht")]
    public string Achternaam_kind {get; set;}
    [Required(ErrorMessage = "De leeftijd van uw kind is verplicht")]
    public int Leeftijd_kind {get; set;}
    public string Geslacht_kind {get; set;}
  
}