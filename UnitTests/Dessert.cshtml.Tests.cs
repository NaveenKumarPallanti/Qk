using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using QuickKitchen.WebSite.Pages;
using System.Linq;

namespace UnitTests.Pages.Dessert
{

    /// <summary>
    /// Tests for the Dessert Page
    /// </summary>
    public class Dessert
    {
        #region TestSetup

        // Page model for the Dessert Page
        public static DessertModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // Mock the logger
            var MockLoggerDirect = Mock.Of<ILogger<DessertModel>>();

            pageModel = new DessertModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the Dessert Page
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {

            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet
    }

}