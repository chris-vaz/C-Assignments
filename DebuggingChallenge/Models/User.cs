#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DebuggingChallenge.Models;

public class User
{
    //Specified the validation message stating that the name is required if field is empty
    [Required(ErrorMessage = "Name is required!")]
    public string Name {get;set;}

    public string? Location {get;set;}
}