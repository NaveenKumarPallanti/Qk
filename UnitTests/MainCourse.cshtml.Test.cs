using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using QuickKitchen.WebSite.Pages;
using System.Linq;

namespace UnitTests.Pages.MainCourse
{

    /// <summary>
    /// Tests for the Main Course Page
    /// </summary>
    public class MainCourse
    {
        #region TestSetup

        // Page model for the Main page
        public static MainCourseModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // Mock the logger
            var MockLoggerDirect = Mock.Of<ILogger<MainCourseModel>>();

            pageModel = new MainCourseModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the Main page
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