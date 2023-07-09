using NUnit.Framework;
using QuickKitchen.WebSite.Components;
using QuickKitchen.WebSite.Services;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Bunit;

namespace UnitTests.Components
{

    /// <summary>
    /// Class containing unit tests for testing SnacksList.razor
    /// </summary>
    public class SnacksListTests : BunitTestContext
    {
        #region Default

        /// <summary>
        /// Test that one of the recipes stored in products.json is in the snacks page
        /// </summary>
        [Test]
        public void SnacksList_Default_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<SnacksList>();

            // Get the Cards returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Yogurt Parfait"));
        }

        #endregion Default

        #region SelectSnack

        /// <summary>
        /// Test that content is returned when selecting the More Info button for the yogurt parfait recipe
        /// </summary>
        [Test]
        public void SelectSnack_Valid_ID_yogurt_parfait_Should_Return_Content()
        {

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Get the ID of the recipe to select
            var id = "MoreInfoButton_yogurt-parfait";

            // Render the page
            var page = RenderComponent<SnacksList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("A quick on-the-go snack that everyone enjoys. It can be easily customized to your liking."));
        }

        #endregion SelectSnack

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
            var id = "MoreInfoButton_yogurt-parfait";

            // Render the page
            var page = RenderComponent<SnacksList>();

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
            var id = "MoreInfoButton_deviled-eggs";

            // Render the page
            var page = RenderComponent<SnacksList>();

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

            // Get the Vote Count
            var postVoteCountSpan = starButtonList[1];

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
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