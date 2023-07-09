using NUnit.Framework;
using QuickKitchen.WebSite.Models;

namespace UnitTests.Models
{

    /// <summary>
    /// Class containing unit tests for ProductModel.cs
    /// </summary>
    internal class ProductModelTests
    {
        #region TestSetup

        // Variable containing test ProductModel object
        public static ProductModel productModel;

        /// <summary>
        /// Function to initialize productModel variable
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            productModel = new ProductModel();
        }

        #endregion TestSetup

        #region ToString

        /// <summary>
        /// Unit test to check that ToString() returns stored values
        /// </summary>
        [Test]
        public void ToString_Should_Return_Stored_Values()
        {

            // Arrange

            // Act

            // The result of ToString()
            var result = productModel.ToString();

            // The expected result of ToString()
            var expected = "{\"Id\":null,\"Category\":null,\"Maker\":null,\"img\":null,\"Url\":null,\"Title\":null,\"Description\":null,\"Ratings\":null,\"Time\":null,\"Ingredients\":null,\"Instructions\":null,\"Comments\":null}";

            // Assert
            Assert.AreEqual(expected, result);
        }

        #endregion ToString
    }

}