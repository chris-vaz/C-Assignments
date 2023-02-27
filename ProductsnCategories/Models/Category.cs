#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsnCategories.Models;
public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Name of the category is required")]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // Our Person class also needs a reference to Subscriptions
    // and contains NO reference to Magazines  
    public List<Association> Associations { get; set; } = new List<Association>();
}