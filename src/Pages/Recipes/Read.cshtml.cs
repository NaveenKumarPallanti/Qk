using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Pages.Recipes
{
    /// <summary>
    /// Model for Read.cshtml
    /// </summary>
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
            if (Product == null)
            {
                return RedirectToPage("../ItemNotFound");
            }
            return null;
        }

        /// <summary>
        /// REST Post request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <param name="name"></param>
        /// <returns>Page</returns>
        public IActionResult OnPost(string id, string comment, string name)
        {
            if (!string.IsNullOrEmpty(comment))
            {
                var newComment = new Comment
                {

                    // The comment is the inputed comment
                    Text = comment,

                    // The name is the inputed name, or "Anonymous" if the name is empty
                    Name = string.IsNullOrEmpty(name) ? "Anonymous" : name,

                    // The date is today's date
                    Date = DateTime.Today.Date
                };

                ProductService.AddComment(id, newComment);
            }

            return RedirectToPage("Read", new { id = id });
        }
    }
}