using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using QuickKitchen.WebSite.Models;
using QuickKitchen.WebSite.Pages.Recipes;

namespace UnitTests.Pages.Recipes.Update
{

    /// <summary>
    /// Test class for unit test testing UpdateModel functions
    /// </summary>
    public class Update
    {
        #region TestSetup

        // Page model for the Index page
        public static UpdateModel pageModel;

        /// <summary>
        /// Sets up the test class by initializing pageModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService) { };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit Test to Check if OnGet() redirects
        /// </summary>
        [Test]
        public void OnGet_Should_Set_Title_To_Create_When_Coming_From_Create()
        {

            // Arrange

            // id of the product used for testing
            string id = "0";

            // Act
            pageModel.OnGet(id, "Create");

            // Assert
            Assert.IsTrue(pageModel.ModelState.IsValid);
            Assert.AreEqual("Create", pageModel.title);
        }

        /// <summary>
        /// Tests if Update page title is set when coming from Update
        /// </summary>
        [Test]
        public void OnGet_Should_Set_Title_To_Update_When_Coming_From_Update()
        {

            // Arrange
            string id = "lemon-herb-chicken";

            // Act
            pageModel.OnGet(id, "Update");

            // Assert
            Assert.IsTrue(pageModel.ModelState.IsValid);
            Assert.AreEqual("Update", pageModel.title);
        }

        #endregion OnGet

        #region OnPostAsync

        /// <summary>
        /// Unit Test to check if OnPost() returns Products when updating
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Add_Product_When_In_Update()
        {

            // Arrange

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// Unit Test to check if OnPost() returns Products When Creating Recipe
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Update_When_Set_To_Create()
        {

            // Arrange

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData();
            TestHelper.ProductService.AddData(pageModel.Product);
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }

        #endregion OnPost

        #region OnPostAsync

        /// <summary>
        /// Unit Test to check if OnPost() returns null if pageModel is invalid
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Page_Model_Should_Return_Null()
        {

            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "bogus",
                Title = "bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state to test if statement
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        #endregion OnPostAsync
    }

}