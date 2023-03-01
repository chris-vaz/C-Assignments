#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
public class MyViewModel
{    
    public Category Category {get;set;}    
    public Product Product {get;set;}
    public List<Category> AllCategories {get;set;}   
    public List<Product> AllProducts {get;set;}   
}