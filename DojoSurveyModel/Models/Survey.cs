#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyModel.Models;
public class Survey
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters in length")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Location is required!")]
    [MinLength(2, ErrorMessage = "Location must be at least 2 characters in length")]
    public string Location { get; set; }
    [Required(ErrorMessage ="Language field is required!")]
    [MinLength(2, ErrorMessage ="Language field must be atleast 2 characters in length")]
    public string Language { get; set; }
    [Required(ErrorMessage ="Comment field is required")]
    [MinLength(5, ErrorMessage ="Comment field must be minimum 5 characters in length")]
    public string Comment { get; set; }

}
