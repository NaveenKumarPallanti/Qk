using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using QuickKitchen.WebSite.Pages.Recipes;
using System.Linq;

namespace UnitTests.Pages.Recipes.Read
{

    /// <summary>
    /// Tests for the Read page
    /// </summary>
    public class ReadTests
    {
        #region TestSetup

        // Page model for the Read page
        public static ReadModel pageModel;

        /// <summary>
        /// Initializes the test class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests the OnGet function of the Read page, product attributes are correctly returned
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {

            // Arrange

            // Act
            pageModel.OnGet("yogurt-parfait");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Yogurt Parfait", pageModel.Product.Title);
            Assert.AreEqual("/images/yogurtParfait/horizontalparfaityogurt-copy.jpg", pageModel.Product.Image);
            Assert.AreEqual("A quick on-the-go snack that everyone enjoys. It can be easily customized to your liking.", pageModel.Product.Description);
            Assert.AreEqual("Prep: 5 minutes | Cook: 0 minutes | Total: 13 minutes", pageModel.Product.Time);
            CollectionAssert.AreEqual(new[] {
                "32 oz. container whole milk plain yogurt, organic recommended",
                "3 tablespoons honey",
                "1 pound fresh or frozen berries",
                "2 cups granola"
            }, pageModel.Product.Ingredients);
            CollectionAssert.AreEqual(new[] {
                "Add honey to the container of yogurt. Stir well.",
                "In a mason jar, layer yogurt and berries. Top with granola."
            }, pageModel.Product.Instructions);
        }

        /// <summary>
        /// Tests OnGet function of the Read page, page redirects if incorrect id is given
        /// </summary>
        [Test]
        public void OnGet_Invalid_Should_Return_Redirect()
        {

            // Arrange

            // Act
            var result = pageModel.OnGet("chicken");

            // Assert
            Assert.IsNotNull(result);
        }

        #endregion OnGet

        #region OnPost

        /// <summary>
        /// Tests the OnPost function of the Read page, valid comment should return the page
        /// </summary>
        [Test]
        public void OnPost_Valid_Comment_Should_RedirectToPageResult()
        {

            // Arrange

            // test product id
            var id = "mango-pudding";

            // test product comment
            var comment = "Loving it!";

            // test product name
            var name = "Food Critic";

            // Act
            var result = pageModel.OnPost(id, comment, name);

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
        }

        /// <summary>
        /// Tests the OnPost function of the Read page, valid comment should create a comment object
        /// </summary>
        [Test]
        public void OnPost_Valid_Comment_Should_Create_New_Comment_Object()
        {

            // Arrange

            // test product id
            var id = "mango-pudding";

            // test product comment
            var comment = "Loving it!";

            // test product name
            var name = "Food Critic";

            // Act

            // Result of OnPost
            var result = pageModel.OnPost(id, comment, name);

            // Get product from database
            var product = TestHelper.ProductService.GetAllData().First(p => p.Id == id);

            // Get new comment from product
            var newComment = product.Comments[0];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(comment, newComment.Text);
            Assert.AreEqual(name, newComment.Name);
        }

        /// <summary>
        /// Tests the OnPost function of the Read page, null name should create Anonymous name in new comment object
        /// </summary>
        [Test]
        public void OnPost_Null_Name_Should_Create_Anonymous_Name_In_New_Comment_Object()
        {

            // Arrange

            // test product id
            var id = "asparagus";

            // test product comment
            var comment = "Loving it!";

            // test product name
            var name = null as string;

            // Act

            // Result of OnPost
            var result = pageModel.OnPost(id, comment, name);

            // Get product from database
            var product = TestHelper.ProductService.GetAllData().First(p => p.Id == id);

            // Get new comment from product
            var newComment = product.Comments[0];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Anonymous", newComment.Name);
        }

        #endregion OnPost
    }

}