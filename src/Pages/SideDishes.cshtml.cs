using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;


namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Class for the Side Dish Page of the website
    /// </summary>
    public class SideDishesModel : PageModel
    {

        // logger for MainCourseModel
        private ILogger<SideDishesModel> _logger;

        // gets the ProductService
        public JsonFileProductService ProductService { get; }

        // gets and sets Products (ProductModel)
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// SideDishesModel constructor; sets _logger to inputted ILogger<SideDishesModel>
        /// and sets ProductService to inputted JsonFileProductService
        /// </summary>
        /// <paramref name="logger"/>
        /// <paramref name="productService"/>
        public SideDishesModel(ILogger<SideDishesModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }
        
        /// <summary>
        /// updates Products with products in products.json
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}