using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Pages
{

	/// <summary>
	/// This is the SearchModel which redirects to the Search page after searching for a recipe.
	/// </summary>
	public class SearchModel : PageModel
	{

		// json file product service
		private readonly JsonFileProductService _productService;

		/// <summary>
		/// This is the constructor for the SearchModel class.
		/// </summary>
		public SearchModel(JsonFileProductService productService)
		{
			_productService = productService;
		}

		// The data to show
		[BindProperty(SupportsGet = true)]

		/// <summary>
		/// The query to search for
		/// </summary>	
		public string Query { get; set; }

		/// <summary>
		/// The results of the search
		/// </summary>
		public List<ProductModel> Results { get; private set; }

		/// <summary>
		/// REST Get request
		/// </summary>
		public void OnGet()
		{
			var recipes = _productService.GetAllData();
			Results = recipes.Where(x => x.Title.Contains(Query, StringComparison.OrdinalIgnoreCase)
				|| x.Category.Contains(Query, StringComparison.OrdinalIgnoreCase))
			.Distinct().ToList();
		}
	}
}