#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;
public class Form
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Email is required!")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "DOB is required!")]
    [FutureDate]
    public DateTime Date { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Let us know your Fav Odd Num")]
    [FavOddNum]
    public int FavOddNum { get; set; }
}
public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Unboxing value and casting it to a DateTime variable
        DateTime date = (DateTime)value;

        // Comparing the data to the current date
        if (date > DateTime.Now)
        {
            // If the date is in the future, return an error message
            return new ValidationResult("You cannot be born today lol");
        }

        // Otherwise, the date is valid
        else return ValidationResult.Success;
    }
}
public class FavOddNumAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {

        int num = (int)value;
        if (num%2==0)
        {
            
            return new ValidationResult("This is not a odd number, dummy");
        }

        else return ValidationResult.Success;
    }
}