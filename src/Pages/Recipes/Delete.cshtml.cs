using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;


namespace QuickKitchen.WebSite.Pages.Recipes
{

    /// <summary>
    /// This is the DeleteModel which allows users to delete a recipe and this is a DeleteModel page.
    /// </summary>
    public class DeleteModel : PageModel
    {

        // In JsonFileProductService, creates an object called ProductService with get.
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Initialization of the ProductService object.
        /// </summary>
        /// <param name="productService"></param>
        public DeleteModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Attribute to populate Recipe with data when the page is submitted.
        [BindProperty]

        // The Recipe property of type ProductModel to get and set ProductModel values.
        public ProductModel Recipe { get; set; }

        /// <summary>
        /// This method will get the recipe that the user wants to delete and display it on the page.
        /// When the user clicks the delete button, OnGet will be called, which displays the recipe the user wants to delete.
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Recipe = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        // This allows the user to delete the recipe and redirects the user to the index page once done
        
        /// <summary>
        /// Post the model back to the page.
        /// The model is in the class variable Product.
        /// Call the data layer to delete that data.
        /// Then return to the index page.
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {   

            if (!ModelState.IsValid)
            {
                
                // return the model back to the page .
                return Page();
            }

            ProductService.DeleteData(Recipe.Id);

            //Redirect to the page Index
            return RedirectToPage("./Index");
        }
    }
}