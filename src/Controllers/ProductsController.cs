using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Services;

namespace QuickKitchen.WebSite.Controllers
{
   
    // Enable several API-specific behaviors
    [ApiController]
    
    // Specify the route for the class
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        
        /// <summary>
        /// Class that defines an ASP.NET Core web API controller named ProductsController.
        /// The controller derives from ControllerBase, which provides access to the core features of ASP.NET Core MVC, such as action results and HTTP context.
        /// </summary>

        /// <summary>
        /// Constructor takes an instance of the JsonFileProductService class as a parameter and assigns it to the ProductService property of the controller.
        /// </summary>
        /// <param name="productService">The ProductsController class has a constructor that takes a </param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // ProductService property is of type JsonFileProductService and is declared with only a getter.
      
        // This means that the property can be read but not modified from outside the class.
        public JsonFileProductService ProductService { get; }

        // The HttpGet attribute is applied to the Get() method of the ProductsController class.
        [HttpGet]

        /// <summary>
        /// Method is an HTTP GET action that returns an IEnumerable of ProductModel objects retrieved from the ProductService.
        /// </summary>
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        // Attribute is applied to the Patch() method of the ProductsController class.
        
        // This attribute specifies that this method is an HTTP PATCH action that handles PATCH requests for product ratings.
        [HttpPatch]

        /// <summary>
        /// Method accepts a RatingRequest object in the request body, which contains a ProductId and a Rating value.
        /// The FromBody attribute on the request parameter indicates that the RatingRequest object should be deserialized from the request body.
        /// </summary>
        /// <param name="request"></param>
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);

            // This method is used to update the rating for a product in the JSON file where the product data is stored,
           
            // and to return an HTTP response to the client to indicate the success of the operation.
            return Ok();
        }

        public class RatingRequest
        {
            /// <summary>
            /// Defines the structure of the data sent in an HTTP PATCH request to update the rating of a product in an ASP.NET Core web API.
            /// The class has two properties: ProductId and Rating,
            /// which are used to represent the unique identifier of the product being rated and the new rating value being assigned to it, respectively.
            /// </summary>

            // Gets and sets recipe ProductId from products.json
            public string ProductId { get; set; }
            
            // Gets and sets recipe Rating from products.json
            public int Rating { get; set; }
        }
    }
}