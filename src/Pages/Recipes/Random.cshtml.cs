using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace QuickKitchen.WebSite.Pages.Recipes
{
    public class RandomModel : PageModel
    {
        // Data middle tier
        public JsonFileProductService ProductService { get; }
        // Collection of the Data
        public IEnumerable<ProductModel> Products { get; private set; }
        // Random object to generate random integers
        public Random rand;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public RandomModel(JsonFileProductService productService)
        {
            ProductService = productService;
            Products = ProductService.GetAllData();
            rand = new Random();
        }
        public IActionResult OnGet()
        {
            // number of recipes store in products.json
            int size = Products.Count();
            // random index for random recipe
            int index = rand.Next(0, size);
            // Randomly selected recipe
            ProductModel model = Products.ElementAt(index);
            return RedirectToPage("./Read", new { Id = model.Id });
        }
    }
}
