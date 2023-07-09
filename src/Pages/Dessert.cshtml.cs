using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;
using System.Collections.Generic;

namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Class for the Dessert Page of the website
    /// </summary>
    public class DessertModel : PageModel
    {

        // logger for DessertModel
        private ILogger<DessertModel> _logger;

        // gets the ProductService
        public JsonFileProductService ProductService { get; }

        // gets and sets Products (ProductModel)
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// DessertModel constructor; sets _logger to inputted ILogger<DessertModel>
        /// and sets ProductService to inputted JsonFileProductService
        /// </summary>
        /// <paramref name="logger"/>
        /// <paramref name="productService"/>
        public DessertModel(ILogger<DessertModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        /// <summary>
        /// updates Products with products in products.json
        /// </summary>
        public void OnGet()
        {

            //updates Products
            Products = ProductService.GetAllData();
        }
    }
}