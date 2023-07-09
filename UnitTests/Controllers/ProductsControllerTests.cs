using NUnit.Framework;
using QuickKitchen.WebSite.Controllers;

namespace UnitTests.Controllers
{

    /// <summary>
    /// Test class for unit test testing ProductsController functions
    /// </summary>
    public class ProductsControllerTests
    {
        #region TestSetup

        // ProductsController test object
        public static ProductsController productsController;

        // RatingRequest test object
        public static ProductsController.RatingRequest ratingRequest;

        [SetUp]
        /// <summary>
        /// Sets up the test class by initializing pageModel
        /// </summary>
        public void TestInitialize()
        {
            productsController = new ProductsController(TestHelper.ProductService)
            {
            };

            ratingRequest = new ProductsController.RatingRequest { Rating = 0, ProductId = "" };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Unit test to check if null is not is returned for Get()
        /// </summary>
        [Test]
        public void Get_Should_Return_Not_Null()
        {

            // Arrange

            // Act
            var result = productsController.Get();

            // Assert
            Assert.IsNotNull(result);
        }

        #endregion OnGet

        #region Patch

        /// <summary>
        /// Unit test to check if no null is returned
        /// </summary>
        [Test]
        public void RatingRequest_No_Null_Return()
        {

            // Arrange

            // Act

            // The result of the Patch method
            var result = productsController.Patch(ratingRequest);

            // Assert
            Assert.IsNotNull(result);
        }

        #endregion Patch
    }

}