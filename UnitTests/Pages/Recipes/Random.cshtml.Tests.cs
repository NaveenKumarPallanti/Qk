using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using QuickKitchen.WebSite.Pages.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Pages.Recipes
{

    /// <summary>
    /// Test class for unit test testing RandomModel functions
    /// </summary>
    internal class RandomTests
    {
        #region TestSetup

        // Page model for the Random page
        public static RandomModel pageModel;

        /// <summary>
        /// Sets up the test class by initializing pageModel
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new RandomModel(TestHelper.ProductService) { };
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