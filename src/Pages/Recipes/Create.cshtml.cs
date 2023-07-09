using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Pages.Recipes
{

    /// <summary>
    /// This is the CreateModel which redirects to the Update page after creating a new ProductModel object to update in the Update page.
    /// </summary>
    public class CreateModel : PageModel
    {

        // Data middle tier
        public JsonFileProductService ProductService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request
        /// </summary>
        public IActionResult OnGet()
        {
            return RedirectToPage("./Update", new { source = "Create", Id = 0 });
        }
    }
}