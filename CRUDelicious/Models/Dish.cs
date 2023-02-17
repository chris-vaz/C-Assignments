#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required]
    public string Name { get; set; } 
    [Required]
    public string Chef { get; set; }
    [Required(ErrorMessage="Tastiness is required!")]
    [Range(1,6)]
    public int Tastiness { get; set; }
    [Required(ErrorMessage="Calories is required!")]
    [MinLength(1, ErrorMessage="Message must be at least 1 character in length.")]
    public int Calories { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}