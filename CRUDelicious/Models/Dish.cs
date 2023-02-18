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
    [Range(1,6)]
    [Required(ErrorMessage="Tastiness is required!")]
    public int? Tastiness { get; set; }
    [Range(1, int.MaxValue, ErrorMessage="Value must be at least 1.")]
    [Required(ErrorMessage="Calories is required!")]
    public int? Calories { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}