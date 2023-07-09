using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using QuickKitchen.WebSite.Pages;

namespace UnitTests.Pages.AboutUs
{

    /// <summary>
    /// Tests for the AboutUs page
    /// </summary>
    public class AboutUsTests
    {
        #region TestSetup

        // Page model for the AboutUs page
        public static AboutUsModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // Mock the logger
            var MockLoggerDirect = Mock.Of<ILogger<AboutUsModel>>();

            pageModel = new AboutUsModel(MockLoggerDirect)
            {

                // Create a page context
                PageContext = TestHelper.PageContext,

                // Create a temp data
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the AboutUs page
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
        }

        #endregion OnGet
    }

}