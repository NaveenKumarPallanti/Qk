using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Moq;
using QuickKitchen.WebSite.Pages;

namespace UnitTests.Resources

{

    /// <summary>
    /// Tests for the REsources page
    /// </summary>
    public class ResourcesTests
    {
        #region TestSetup

        // Page model for the Resources page
        public static ResourcesModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // Mock the logger
            var MockLoggerDirect = Mock.Of<ILogger<ResourcesModel>>();

            pageModel = new ResourcesModel(MockLoggerDirect)
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
        /// Tests the OnGet function of the Resources page
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