using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NUnit.Framework;
using QuickKitchen.WebSite.Pages.Recipes;

namespace UnitTests.Pages.Recipes.Index
{

    /// <summary>
    /// Tests for the Index page
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        // Page context for the Index page
        public static PageContext pageContext;

        // Page model for the Index page
        public static IndexModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the Index page, products are returned
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet
    }

}