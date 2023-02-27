#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsnCategories.Models;
public class Association
{
    [Key]
    public int AssociationId { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    // Navigation Properties
    public Product? Product {get;set;}
    public Category? Category {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


    
    // Our navigation property to track which Chef made this Dish
    // It is VERY important to include the ? on the datatype or this won't work!
    // public Chef? Cook { get; set; }
}