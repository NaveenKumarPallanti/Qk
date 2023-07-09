using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuickKitchen.WebSite.Models
{

    /// <summary>
    /// This class contains the methods for getting and setting attributes in products.json, which are the recipe attributes.
    /// This also contains a method for converting a ProductModel (an object of this class) to a JSON string.
    /// </summary>
    public class ProductModel
    {

        // Get and set the recipe Id (based on the name of the recipe)
        public string Id { get; set; }

        // Get and set the recipe Category (main, side, snack, dessert)
        [DisplayName("Category - Enter Main, Side, Snack or Dessert")]
        public string Category { get; set; }

        // Get and set the recipe Maker (who posted the recipe)
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        // Get and set the recipe Image
        [DisplayName("Image - Enter a valid URL starting with http:// or a valid file path")]
        public string Image { get; set; }

        // Get and set the URL of where the recipe originated from
        [DisplayName("Source URL - Enter a valid URL starting with http://")]
        public string Url { get; set; }

        // Get and set the recipe Title (name of the recipe)
        [DisplayName("Title - Enter a recipe title")]
        public string Title { get; set; }

        // Get and set the recipe Description
        [DisplayName("Description - Enter a short description")]
        public string Description { get; set; }

        // Get and set the recipe Ratings (from 1 to 5)
        public int[] Ratings { get; set; }

        // Get and set the recipe Time (how long to prep, how long to cook, and total time; all in minutes)
        [DisplayName("Time - Enter prep time, cook time and total time in minutes")]
        public string Time { get; set; }

        // Get and set the recipe Ingredients (list of ingredient quantities)
        [DisplayName("Ingredients - Enter the | symbol to separate each ingredient")]
        public string[] Ingredients { get; set; }

        // Get and set the recipe Instructions
        [DisplayName("Instructions - Enter the | symbol to separate each instruction")]
        public string[] Instructions { get; set; }

        //Get and set the list of comments for a product.
        public List<Comment> Comments { get; set; }

        // Convert ProductModel to JSON string
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }

    /// <summary>
    /// This class contains the methods for getting and setting attributes in comments.json, which are the comment attributes.
    /// </summary>
    public class Comment
    {

        // Get and set the Text of comment 
        public string Text { get; set; }

        // Get and set the Name of comment 
        public string Name { get; set; }

        // Get and set the Date of comment .
        public DateTime Date { get; set; }
    }
}