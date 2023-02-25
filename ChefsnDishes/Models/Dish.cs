#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsnDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "First Name is required")]
    public string Name { get; set; }
    public string Calories { get; set; }
    public string ChefName { get; set; }
    public string Tastiness { get; set; }
    public DateOnly dob { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}