using System.Linq;
using NUnit.Framework;
using QuickKitchen.WebSite.Pages;

namespace UnitTests.Pages.Search
{

    /// <summary>
    /// Tests for the Search page
    /// </summary>
    public class Search
    {
        #region TestingSetup

        // Page model for the Search page
        public static SearchModel pageModel;

        /// <summary>
        /// Initialize the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new SearchModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the Search page, returns requested product for a valid search
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {

            // Arrange
            pageModel.Query = "Mango";

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Results.ToList().Any());
        }

        #endregion OnGet
    }

}