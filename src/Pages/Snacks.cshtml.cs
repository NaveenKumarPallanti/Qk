using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;


namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Class for the Snacks Page of the website
    /// </summary>
    public class SnacksModel : PageModel
    {

        // logger for SnacksModel
        private ILogger<SnacksModel> _logger;

        // gets the ProductService
        public JsonFileProductService ProductService { get; }

        // gets and sets Products (ProductModel)
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// SnacksModel constructor; sets _logger to inputted ILogger<SnacksModel>
        /// and sets ProductService to inputted JsonFileProductService
        /// </summary>
        /// <paramref name="logger"/>
        /// <paramref name="productService"/>
        public SnacksModel(ILogger<SnacksModel> logger, JsonFileProductService productService)
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