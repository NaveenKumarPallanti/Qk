using QuickKitchen.WebSite.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickKitchen.WebSite.Models;

namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Class for the Main Course Page of the website
    /// </summary>
    public class MainCourseModel : PageModel
    {

        // logger for MainCourseModel
        private ILogger<MainCourseModel> _logger;

        // gets the ProductService
        public JsonFileProductService ProductService { get; }

        // gets and sets Products (ProductModel)
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// MainCourseModel constructor; sets _logger to inputted ILogger<MainCourseModel>
        /// and sets ProductService to inputted JsonFileProductService
        /// </summary>
        /// <paramref name="logger"/>
        /// <paramref name="productService"/>
        public MainCourseModel(ILogger<MainCourseModel> logger, JsonFileProductService productService)
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