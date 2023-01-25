#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;
public class Date
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Name is required!")]
    [FutureDate]
    public DateTime Birthday { get; set; }
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
            return new ValidationResult("Date must be in the past");
        }

        // Otherwise, the date is valid
        else return ValidationResult.Success;
    }
}