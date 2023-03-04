# Optional: Passing Data to Partials
Learning Objectives:
- Create a Model for passing multiple pieces of data through ViewModel.

Important: This module shows how to pass multiple pieces of data through ViewModel. You will rarely, if ever, need to use this method, but it's good to know about if you are feeling confident in your current skills.

Taking advantage of partials to allow for multiple forms on a single view is straightforward enough. However, what about a scenario in which there is a form on one side of the page and data from our database on the other side? How could we handle this scenario?

ViewBag could solve this for us easily (a model for the form, a ViewBag for the data). However, we are going to start directing you to move away from using ViewBag from here on out. The reason is that while ViewBag is handy, using ViewModels for passing data is considered best practice due to its more explicit casting (our program never knows what exactly is in ViewBag) which will allow us greater functionality on our front end and fewer chances for errors.

But now we're back at our earlier dilemma: we can't use two models on one page. In addition, we aren't simply using a model in one of these to define a form. This model will have data pre-loaded into it, which means we need to send data from our controller to our partial.

The trick here is in understanding how ViewModel works. A ViewModel is designed to pass an object or entity from our back end to our front end. As long as we are being explicit about what our ViewModel is, this can be anything.

So...what's stopping us from making an object that contains all the models and data types we need and passing that "single object" down as our ViewModel?

This is what we mean: create a new model in your Models folder and call it MyViewModel.

### MyViewModel.cs
```cs 
#pragma warning disable CS8618
namespace YourNamespace.Models;
public class MyViewModel
{    
    public Product Product {get;set;}    
    public List<Product> AllProducts {get;set;}
}
```
For all intents and purposes, MyViewModel is a single object. This means it passes ViewModel's requirements and can be used as a model.

### Index.cshtml
```cs 
@model MyViewModel
<div class="d-flex">
    @await Html.PartialAsync("_ProductForm")
    @await Html.PartialAsync("_AllProducts")
</div>
```

### HomeController.cs
```cs 
// All other code
[HttpGet("")]    
public IActionResult Index()    
{   
    MyViewModel MyModels = new MyViewModel
    {
        AllProducts = _context.Products.ToList()
    };     
    return View(MyModels);    
}
```

There are a few key points to note here:

1. We had to create a new instance of MyViewModel to fill in.
2. We filled in AllProducts from MyViewModel with a query.
3. We did not need to make any mention of the singular Product (because it is only for our form).
4. Once our model was ready, we passed it down as a ViewModel like normal.

The final step we need to take is to pass this information down to our partial. Thankfully, PartialAsync makes it very easy to pass the data along like so:

### Index.cshtml
```cs 
// All other code
@model MyViewModel
<div class="d-flex">
    @await Html.PartialAsync("_ProductForm", Model.Product)
    @await Html.PartialAsync("_AllProducts", Model.AllProducts)
</div>
```

And we're done! Over on our respective partials, we can treat everything as normal. There are no changes that need to be made.

**Important**: The method of making a ViewModel to store multiple models is something that, while interesting to know, is not likely to be used often in your projects. We introduce it to show you how you can work around the issue of passing down one model to a page, but the rule of thumb is if your page only needs one model do not use this. It will only unnecessarily complicate your code.

### Check Your Knowledge With These Challenges!
Debugging challenge: Once you have your data being passed down through MyViewModel, try invoking an error on your form. This will cause an error if you are missing a crucial extra step needed somewhere in your controller. Ask yourself: why is this problem happening and what can I do to fix it?
Hint: Try commenting out the AllProducts partial and see if the problem persists.





