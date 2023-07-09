using System;
using NUnit.Framework;
using QuickKitchen.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Recipes.Services
{
    public class JsonFileProductServiceTests
    {

        #region TestSetup

        /// <summary>
        /// Test class for unit test testing JsonFileProductService.cs functions
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating

        /// <summary>
        /// Unit test to check if false is returned for an invalid product
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {

            // Arrange

            // Act

            // Result of adding a rating to a null product
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Unit test to check if true is returned when there are no ratings
        /// </summary>
        [Test]
        public void AddRating_Product_With_No_Ratings_Should_Return_True()
        {

            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Get the count of ratings
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);

            // Get the First data item
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// Unit test to check if false is returned for an invalid rating
        /// </summary>
        [Test]
        public void AddRating_InValid_Rating_Should_Return_False()
        {

            // Arrange
            var data = TestHelper.ProductService.GetAllData().First();

            // Act

            // Result of adding an invalid rating
            var result2 = TestHelper.ProductService.AddRating(data.Id, 6);

            // Result of adding an invalid rating
            var result1 = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.IsFalse(result2);
            Assert.IsFalse(result1);
        }

        /// <summary>
        /// Unit test to check if true is returned for a valid rating
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {

            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();

            // Get the count of ratings
            var countOriginal = data.Ratings.Length;

            // Act

            // Result of adding a valid rating
            var result = TestHelper.ProductService.AddRating(data.Id, 4);

            // Result of adding a valid rating
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(4, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// Unit test to check if false is returned for an invalid product
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Should_Return_False()
        {

            // Arrange

            // Act

            // Result of adding a rating to an invalid product
            var result = TestHelper.ProductService.AddRating("invalid", 1);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Unit test to check if false is returned when the product is not found
        /// </summary>
        [Test]
        public void AddRating_Product_Not_Found_Return_False()
        {

            // Arrange

            // Result of adding a rating to a product that is not found
            var result = TestHelper.ProductService.AddRating("999", 1);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Unit test to check if null is not returned for GetAllData()
        /// </summary>
        [Test]
        public void GetAllData_Should_Return_Not_Null()
        {

            // Arrange

            // Act
            
            // Result of getting all data
            var result = TestHelper.ProductService.GetAllData();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Unit test to check if true is returned for a rating on the last product
        /// </summary>
        [Test]
        public void AddRating_Rating_On_Last_Product_Should_Return_True()
        {

            // Arrange

            // Data of the last product
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act

            // Result of adding a rating to the last product
            var result = TestHelper.ProductService.AddRating(data.Id, 2);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Unit test to check if false is returned for a nonexistent product
        /// </summary>
        [Test]
        public void AddRating_Nonexistent_Product_Should_Return_False()
        {

            // Arrange

            // Product ID of a nonexistent product
            var productId = "nonexistent-product";

            // Act

            // Result of adding a rating to a nonexistent product
            var result = TestHelper.ProductService.AddRating(productId, 5);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Unit test to check if adding null ratings creates an array
        /// </summary>
        [Test]
        public void AddRating_Null_Ratings_Create_Array()
        {

            // Arrange

            // Data of the first product
            var product = TestHelper.ProductService.CreateData();
            TestHelper.ProductService.AddData(product);

            // Act
            TestHelper.ProductService.AddRating(product.Id, 5);

            // Data of the first product after adding a rating
            var productAfterAddingARating = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(product.Id));
            
            // Assert
            Assert.IsInstanceOf<int[]>(productAfterAddingARating.Ratings);
        }

        #endregion AddRating

        #region UpdateData
        /// <summary>
        /// This function tests UpdateData() to check if null is returned for a null product
        /// </summary>
        [Test]
        public void UpdateData_Should_Return_Null()
        {

            // Arrange

            // Create a new product
            var product = TestHelper.ProductService.CreateData();
            TestHelper.ProductService.AddData(product);

            // Delete the product
            product = TestHelper.ProductService.DeleteData(product.Id);

            // Act

            // Result of updating a null product
            var result = TestHelper.ProductService.UpdateData(product);

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// This function tests UpdateData() to see if the user input for category is stored
        /// </summary>
        [Test]
        public void UpdateData_Should_Return_Inputted_Category()
        {

            // Arrange

            // Create a new product
            var product = TestHelper.ProductService.CreateData();
            TestHelper.ProductService.AddData(product);

            // Set the category to "Main"
            product.Category = "Main";

            // Create a new product
            var test = TestHelper.ProductService.CreateData();

            // Set the category to "Main"
            test.Category = "Main";

            // Act

            // Result of updating a product
            product = TestHelper.ProductService.UpdateData(product);

            // Assert
            Assert.AreEqual(product.Category, test.Category);
        }

        #endregion UpdateData

        #region AddComment

        /// <summary>
        /// This function tests AddComment() to check if a valid comment is added to a valid product
        /// </summary>
        [Test]
        public void AddComment_Valid_Product_Valid_Comment_Should_Add_Comment()
        {

            // Arrange

            // The product id of the test data
            var productId = "yogurt-parfait";

            // The comment to add
            var comment = new Comment
            {
                // The text of the comment
                Text = "Loving it!",

                // The name of the commenter
                Name = "Food Critic",

                // The date of the comment
                Date = DateTime.Today.Date
            };

            // Act
            TestHelper.ProductService.AddComment(productId, comment);
            TestHelper.ProductService.AddComment(productId, comment);
            TestHelper.ProductService.AddComment(productId, comment);

            // The product with the added comment
            var product = TestHelper.ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(productId));
            
            // Assert
            Assert.AreEqual(3, product.Comments.Count);
            Assert.AreEqual(comment.Text, product.Comments.Last().Text);
            Assert.AreEqual(comment.Name, product.Comments.Last().Name);
            Assert.AreEqual(comment.Date, product.Comments.Last().Date);
        }

        #endregion AddComment
    }

}