using NUnit.Framework;
using QuickKitchen.WebSite.Pages.Recipes;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Recipes.Create
{

    /// <summary>
    /// Test class for unit test testing CreateModel functions
    /// </summary>
    public class CreateTest
    {
        #region TestSetup

        // Page model for the Create page
        public static CreateModel pageModel;

        /// <summary>
        /// Sets up the test class by initializing pageModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService) { };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit Test to Check if OnGet() redirects
        /// </summary>
        [Test]
        public void OnGet_Should_Redirect()
        {

            // Arrange

            // Act
            var result = pageModel.OnGet();

            // Assert
            Assert.IsTrue(result.GetType() == typeof(RedirectToPageResult));
        }

        #endregion OnGet
    }

}