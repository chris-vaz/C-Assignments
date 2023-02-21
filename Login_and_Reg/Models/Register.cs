#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Login_and_Reg.models;
public class User
{    
    [Key]    
    public int UserId { get; set; }
    
    [Required]    
    public string FirstName { get; set; }
    
    [Required]        
    public string LastName { get; set; }     
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }    
    
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password { get; set; } 
    
    public string PasswordConfirm { get; set; }   
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;   
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}