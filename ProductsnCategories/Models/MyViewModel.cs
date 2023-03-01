#pragma warning disable CS8618
namespace ProductsnCategories.Models;
using ProductsnCategories.Models;
public class MyViewModel
{
    public Product Product { get; set; }
    public Category Category { get; set; }
    public List<Product> AllProducts { get; set; }
    public List<Category> AllCategories { get; set; }
}