using System;
using System.ComponentModel.DataAnnotations;


public class Aanmelding
{
    [Key]
    public int Id {get; set;}
    [Required]
    [Display(Name = "Voornaam")]
    public string VoorNaam {get; set;}
    [Required]
    [Display(Name = "Achternaam")]
    public string AchterNaam {get; set;}
    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy/H/mm}")]
    public DateTime Datum {get; set;}
    [Required]
    [Display(Name = "Hulpverlener")]
    public string Hulpverlener {get; set;}   
}