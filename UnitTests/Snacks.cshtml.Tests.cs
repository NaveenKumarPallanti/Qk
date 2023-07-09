using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using QuickKitchen.WebSite.Pages;
using System.Linq;


namespace UnitTests.Pages.Snacks
{

    /// <summary>
    /// Tests for the Snacks Page
    /// </summary>
    public class Snacks
    {
        #region TestSetup

        // Page model for the Snacks Page
        public static SnacksModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // Mock the logger
            var MockLoggerDirect = Mock.Of<ILogger<SnacksModel>>();

            pageModel = new SnacksModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the Snacks Page
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