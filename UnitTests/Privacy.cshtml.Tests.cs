using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using QuickKitchen.WebSite.Pages;

namespace UnitTests.Pages.Privacy
{

    /// <summary>
    /// Tests for the Privacy page
    /// </summary>
    public class PrivacyTests
    {
        #region TestSetup

        // Page model for the Privacy page
        public static PrivacyModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // Mock the logger
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();

            pageModel = new PrivacyModel(MockLoggerDirect)
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
        /// Tests the OnGet function of the Privacy page
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