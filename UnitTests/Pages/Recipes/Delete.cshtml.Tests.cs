using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Pages.Recipes;
using System.Linq;

namespace UnitTests.Pages.Recipes.Delete
{

    /// <summary>
    /// Test class for unit test testing DeleteModel functions
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup

        // Page model for the Delete page
        public static DeleteModel pageModel;

        /// <summary>
        /// Sets up the test class by initializing pageModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit Test to check if OnGet() returns products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {

            // Arrange

            // Act
            pageModel.OnGet("grilled-cod-with-spinach-and-tomatoes");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Grilled Cod with Spinach and Tomatoes", pageModel.Recipe.Title);
        }

        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// Unit Test to Check if OnPost() returns products
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {

            // Arrange

            // Create the product to delete
            pageModel.Recipe = TestHelper.ProductService.CreateData(); 
            pageModel.Recipe.Title = "Example to Delete";

            // Update the product
            TestHelper.ProductService.UpdateData(pageModel.Recipe);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Recipe.Id)));
        }

        /// <summary>
        /// Unit Test to Check if OnPost() if false is returned when the pageModel is invalid
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {

            // Arrange
            pageModel.Recipe = new ProductModel
            {
                Id = "bogus",
                Title = "bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPostAsync
    }

}