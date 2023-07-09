using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Pages.Recipes
{

    /// <summary>
    /// Index Page will return all the data to show.
    /// </summary>
    public class IndexModel : PageModel
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        /// <param name="productService"></param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Data Service
        public JsonFileProductService ProductService { get; }

        // Collection of the Data
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// REST OnGet, return all data.
        /// </summary>
        public void OnGet()
        {

            // return all data.
            Products = ProductService.GetAllData();
        }
    }
}