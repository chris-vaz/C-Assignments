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

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true, NullDisplayText = "dob required")]
    [Required(ErrorMessage = "DOB required")]
    [MinimumAge(18, ErrorMessage = "Chef must be at least 18 years old.")]
    public DateTime? dob { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Our navigation property to track the many Dishes our chef has made
    // Be sure to include the part about instantiating a new List!
    public List<Dish> allDishes { get; set; } = new List<Dish>();

    // Adding custom minimum Age attribute
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult(ErrorMessage ?? $"DOB required");
            }

            DateTime dateOfBirth;
            if (DateTime.TryParse(value.ToString(), out dateOfBirth))
            {
                var age = DateTime.Today.Year - dateOfBirth.Year;
                if (dateOfBirth > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
                if (age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? $"Minimum age of {_minimumAge} years required.");
        }
    }
}
