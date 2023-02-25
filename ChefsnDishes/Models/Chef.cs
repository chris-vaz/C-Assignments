#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsnDishes.Models;
public class Chef
{
    [Key]
    public int ChefId { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Date of Birth is required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime dob { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;



    public int Age
    {
        get
        {
            DateTime now = DateTime.Now;
            int age = now.Year - dob.Year;

            if (now.Month < dob.Month || (now.Month == dob.Month && now.Day < dob.Day))
            {
                age--;
            }

            return age;
        }
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (dob > DateTime.Now)
        {
            yield return new ValidationResult("Date of Birth must be in the past.", new[] { "dob" });
        }

        if (Age < 18)
        {
            yield return new ValidationResult("Chef must be at least 18 years old.", new[] { "dob" });
        }
    }
}