using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsCategoriesBrandon.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{

    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult AllProducts()
    {
        MyViewModel AllProducts = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };
        return View(AllProducts);
    }

    [HttpPost("product/create")]

    public IActionResult CreateProduct(Product newProduct)
    {

        if (ModelState.IsValid)
        {
            Console.WriteLine(newProduct.Name);
            Console.WriteLine(newProduct.Description);
            Console.WriteLine(newProduct.Price);

            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("AllProducts");
        }

        else
        {
            MyViewModel AllProducts = new MyViewModel
            {
                AllProducts = _context.Products.ToList()
            };
            return View("AllProducts", AllProducts);
        }
    }

    [HttpGet("product/{ProductId}")]
    public IActionResult Product(int ProductId)
    {

        Product? displayProduct = _context.Products.Include(a => a.AssociationsToCategories).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == ProductId);

        List<Category> NotUsedCategory = _context.Categories.ToList();

        foreach (Category c in NotUsedCategory.ToList())
        {
            foreach (Association category in displayProduct.AssociationsToCategories.ToList())
            {
                if (category.Category.Name == c.Name)
                {
                    Console.WriteLine("HIT");
                    NotUsedCategory.Remove(category.Category);
                }

            }
        }

        MyViewModel AllInfo = new MyViewModel
        {
            Product = displayProduct,
            AllCategories = NotUsedCategory
        };
        return View(AllInfo);
    }

    [HttpPost("/product/addCategory")]
    public IActionResult CreateAssociation(Association newAssociation)
    {

        if (ModelState.IsValid)
        {
            Console.WriteLine(newAssociation.CategoryId);
            Console.WriteLine(newAssociation.ProductId);
            _context.Add(newAssociation);
            _context.SaveChanges();
            return Redirect($"/product/{newAssociation.ProductId}");
        }

        else
        {
            return View($"/product/{newAssociation.ProductId}");
        }
    }

    [HttpGet("categories")]
    public IActionResult AllCategories()
    {
        MyViewModel AllCategories = new MyViewModel
        {
            AllCategories = _context.Categories.ToList()
        };
        return View(AllCategories);
    }

    [HttpPost("category/create")]

    public IActionResult CreateCategory(Category newCategory)
    {

        if (ModelState.IsValid)
        {

            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("AllCategories");
        }

        else
        {
            MyViewModel AllCategories = new MyViewModel
            {
                AllCategories = _context.Categories.ToList()
            };
            return View("AllCategories", AllCategories);
        }
    }

    [HttpGet("category/{CategoryId}")]
    public IActionResult Category(int CategoryId)
    {

        Category? displayCategory = _context.Categories.Include(a => a.AssociationsToProducts).ThenInclude(a => a.Product).FirstOrDefault(c => c.CategoryId == CategoryId);

        List<Product> NotUsedProduct = _context.Products.ToList();

        foreach (Product p in NotUsedProduct.ToList())
        {
            foreach (Association product in displayCategory.AssociationsToProducts.ToList())
            {
                if (product.Product.Name == p.Name)
                {
                    Console.WriteLine("HIT");
                    NotUsedProduct.Remove(product.Product);
                }

            }
        }

        MyViewModel AllInfo = new MyViewModel
        {
            Category = displayCategory,
            AllProducts = NotUsedProduct
        };
        return View(AllInfo);
    }

    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}