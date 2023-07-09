using NUnit.Framework;
using QuickKitchen.WebSite.Components;
using QuickKitchen.WebSite.Services;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Bunit;

namespace UnitTests.Components
{

    /// <summary>
    /// Class containing unit tests for testing MainCourseList.razor
    /// </summary>
    public class MainCourseListTests : BunitTestContext
    {
        #region Default

        /// <summary>
        /// Test that one of the recipes stored in products.json is in the main course page
        /// </summary>
        [Test]
        public void MainCourseList_Default_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<MainCourseList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Simple Lemon-Herb Chicken"));
        }

        #endregion Default

        #region SelectMainCourse

        /// <summary>
        /// Test that content is returned when selecting the More Info button for the Lemon Herb Chicken recipe
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_lemon_herb_chicken_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Get the ID of the recipe to select
            var id = "MoreInfoButton_lemon-herb-chicken";

            // Render the page
            var page = RenderComponent<MainCourseList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("Lemon-herb chicken is a simple, quick, and delicious dish. All you need are a few herbs, a lemon, and of course, the chicken! The amount of spices are completely up to you. You can add more or less according to your taste."));
        }

        #endregion SelectMainCourse

        #region SubmitRating

        /// <summary>
        /// Test that a recipe with no votes is updated properly after the first vote
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Get the ID of the recipe to select
            var id = "MoreInfoButton_gong-zai-noodle-soup";

            // Render the page
            var page = RenderComponent<MainCourseList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            var preVoteCountSpan = starButtonList[1];

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count
            var postVoteCountSpan = starButtonList[1];

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }


        /// <summary>
        /// Test that a recipe with votes updates a new vote properly
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Get the ID of the recipe to select
            var id = "MoreInfoButton_grilled-cod-with-spinach-and-tomatoes";

            // Render the page
            var page = RenderComponent<MainCourseList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            var preVoteCountSpan = starButtonList[1];

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("6 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));

        }

        #endregion SubmitRating
    }

}