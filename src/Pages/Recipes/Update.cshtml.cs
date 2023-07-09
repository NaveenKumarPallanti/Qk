using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Pages.Recipes
{

    /// <summary>
    /// This is the UpdateModel which provides functionality to update the JSON file with user inputted recipe information.
    /// </summary>
    public class UpdateModel : PageModel
    {

        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The product property to get and set ProductModel values for this object
        [BindProperty]
        public ProductModel Product { get; set; }

        // Webpage title
        [BindProperty]
        public string title { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the Data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id, string source)
        {

            if (source == "Create")
            {

                // Set the page title based on the source
                title = "Create";
               
                Product = ProductService.CreateData();
            }
            else
            {

                // Set the page title based on the source
                title = "Update";
                
                // Retrieve the product with the given ID from the data store
                Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            }

            // Create a new ViewDataDictionary if it doesn't exist
            if (PageContext.ViewData == null)
            {
                PageContext.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());
            }
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                //the model back to the page
                return Page();
            }

            //the data layer to Update or Add that data
            var data = ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(Product.Id));
            if (data == null) ProductService.AddData(Product);
            else ProductService.UpdateData(Product);

            // return to the index page
            return RedirectToPage("./Index");
        }
    }
}