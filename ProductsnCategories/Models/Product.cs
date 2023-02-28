#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsnCategories.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Name of the product is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    // [Required(ErrorMessage = "Name of the Chef is required")]
    // public string ChefName { get; set; }
    [Required(ErrorMessage = "Price of the product is required")]
    public float Price { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Our Person class also needs a reference to Subscriptions
    // and contains NO reference to Magazines  
    public List<Association> PAssociations { get; set; } = new List<Association>();
}