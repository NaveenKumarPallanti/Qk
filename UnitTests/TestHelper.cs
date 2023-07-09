using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using QuickKitchen.WebSite.Services;

namespace UnitTests
{

    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    ///
    /// Action Contect
    ///
    /// The View Data and Teamp Data
    ///
    /// The Product Service
    /// </summary>
    public static class TestHelper
    {

        // Web Host Environment
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;

        // Url Helper Factory
        public static IUrlHelperFactory UrlHelperFactory;

        // Http Context
        public static DefaultHttpContext HttpContextDefault;

        // Web Host Environment
        public static IWebHostEnvironment WebHostEnvironment;

        // Model State
        public static ModelStateDictionary ModelState;

        // Action Context
        public static ActionContext ActionContext;

        // Model Metadata Provider
        public static EmptyModelMetadataProvider ModelMetadataProvider;

        // View Data
        public static ViewDataDictionary ViewData;

        //Temp Data
        public static TempDataDictionary TempData;

        // Page Context
        public static PageContext PageContext;

        // Product Service
        public static JsonFileProductService ProductService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {

            // Create a new Mock Web Host Environment
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);
            MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            // Create a new Http Context
            HttpContextDefault = new DefaultHttpContext()
            {
                TraceIdentifier = "trace",
            };
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            // Create a new Model State
            ModelState = new ModelStateDictionary();

            // Create a new Action Context
            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            // Create a new Model Metadata Provider
            ModelMetadataProvider = new EmptyModelMetadataProvider();

            // Create a new View Data
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);

            // Create a new Temp Data
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            PageContext = new PageContext(ActionContext)
            {
                // Set the View Data
                ViewData = ViewData,

                // Set the Temp Data
                HttpContext = HttpContextDefault
            };

            // Create a new Product Service
            ProductService = new JsonFileProductService(MockWebHostEnvironment.Object);

            JsonFileProductService productService;

            // Create a new Product Service
            productService = new JsonFileProductService(TestHelper.MockWebHostEnvironment.Object);
        }

    }

}