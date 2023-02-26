#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsnDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "Name of the dish is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Calories is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int? Calories { get; set; }
    // [Required(ErrorMessage = "Name of the Chef is required")]
    // public string ChefName { get; set; }
    [Required(ErrorMessage = "Level of tastiness is required")]
    [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int? Tastiness { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Our navigation property to track which Chef made this Dish
    // It is VERY important to include the ? on the datatype or this won't work!
    public Chef? Cook { get; set; }
}