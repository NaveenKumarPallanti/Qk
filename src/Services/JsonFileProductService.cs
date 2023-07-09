using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using QuickKitchen.WebSite.Models;
using Microsoft.AspNetCore.Hosting;

namespace QuickKitchen.WebSite.Services
{

    /// <summary>
    /// Class that provides functionality for getting and adding recipe data from products.json
    /// </summary>
    public class JsonFileProductService
    {

        /// <summary>
        /// JsonFileProductService class constructor; sets WebHostEnvironment to the inputed IWebHostEnvironment
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;// Assigning the provided webHostEnvironment parameter to the WebHostEnvironment property of the class
        }

        // Gets the WebHostEnvironment
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Gets the JsonFileName, which is the path to products.json
        private string JsonFileName
        {
            get
            {
                // Combines the web root path, "data" folder, and the filename "products.json" to form the complete path to the JSON file
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

            }
        }
        
        /// <summary>
        /// Gets all the data that is stored in json file and returns it
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<ProductModel> GetAllData()
        {
            // Open the JSON file for reading
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {

                // Deserialize the JSON content into an array of ProductModel objects

                // using JsonSerializer and specified options
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {

                        // Ignore case when mapping JSON property names to object properties
                        PropertyNameCaseInsensitive = true
                    });
            }
        }


        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the update
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {

            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            // Get all product data
            var products = GetAllData();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exists, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }

        /// <summary>
        /// Find the data record
        /// Update the fields
        /// Save to the data store
        /// </summary>
        /// <param name="data"></param>
        public ProductModel UpdateData(ProductModel data)
        {

            // product variable holds all the data stored in product.json
            var products = GetAllData();

            // productData variable holds data for given for new recipe
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));

            // If the product does not exist, return null
            if (productData == null)
            {
                return null;
            }

            // Format and update the data to the new passed-in values
            productData.Title = data.Title;
            productData.Description = data.Description;
            productData.Category = data.Category;
            productData.Time = data.Time;

            // Check if the new data contains ingredients
            if (data.Ingredients != null)
            {

                // Split the ingredients string by '|' delimiter and assign to productData
                data.Ingredients = data.Ingredients[0].Split('|');
                productData.Ingredients = data.Ingredients;
            }

            // Check if the new data contains instructions
            if (data.Instructions != null)
            {

                // Split the instructions string by '|' delimiter and assign to productData
                data.Instructions = data.Instructions[0].Split('|');
                productData.Instructions = data.Instructions;
            }

            // Update the URL and Image properties
            productData.Url = data.Url;
            productData.Image = data.Image;

            // here saveProducts is modified to SaveData.
            SaveData(products); 

            // Return the updated product data
            return productData;
        }

        /// <summary>
        /// Save All products data to storage
        /// </summary>
        /// <param name="products"></param>
        private void SaveData(IEnumerable<ProductModel> products)
        {
            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {

                        // Skip validation checks for improved performance
                        SkipValidation = true,

                        // Format the JSON output with indentation for readability
                        Indented = true
                    }),

                    // The collection of ProductModel objects to be serialized
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {

            // Variable to hold a ProductModel object to hold autofill values
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "",
                Maker = "",
                Category = "",
                Description = "",
                Time = "Prep: ? minutes | Cook: ? minutes | Total: ? minutes",
                Ingredients = new string[1] { "" },
                Instructions = new string[1] { "" },
                Url = "",
                Image = "",
            };

            // Return the updated product data
            return data;
        }

        /// <summary>
        /// Adds new ProductModel object data to products.json
        /// </summary>
        /// <param name="data"></param>
        public void AddData(ProductModel data)
        {
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            // Save the updated data back to the data store
            SaveData(dataSet);
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductModel</returns>
        public ProductModel DeleteData(string id)
        {

            // Get the current set and append the new record to it
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            // Get all the data that does not have the same id as what is given and store it in newDataSet
            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// Add comment to the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="comment"></param>
        public void AddComment(string productId, Comment comment)
        {

            // Get the current set
            var products = GetAllData();

            // Find the product that matches the productId
            var product = products.FirstOrDefault(x => x.Id.Equals(productId));

            // If the product does not have any comments yet, create a new list and add the comment
            if (product.Comments == null)
            {
                product.Comments = new List<Comment> { comment };
            }
            else
            {

                // If the product already has existing comments, add the new comment to the list
                product.Comments.Add(comment);
            }

            // Save the updated product data back to the data store
            SaveData(products);
        }
    }
}