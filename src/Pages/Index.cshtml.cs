using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Class for the home page of the website
    /// </summary>
    public class IndexModel : PageModel
    {

        // logger for IndexModel

        // private readonly ILogger<IndexModel> _logger;



        /// <summary>
        /// IndexModel constructor; sets _logger to inputted ILogger<IndexModel>
        /// and sets ProductService to inputted JsonFileProductService
        /// </summary>
        public IndexModel(ILogger<IndexModel> logger,JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // logger for IndexModel
        private ILogger<IndexModel> _logger;

        // gets the ProductService
        public JsonFileProductService ProductService { get; }

        // gets and sets Products (ProductModel)
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// updates Products with products in products.json
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}