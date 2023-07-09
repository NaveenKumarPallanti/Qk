using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace QuickKitchen.WebSite.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

    /// <summary>
    /// Error Page properties and functions
    /// </summary>
    public class ItemNotFoundModel : PageModel
    {

        // get and set the RequestId
        public string RequestId { get; set; }

        // ShowRequestId is true if RequestId is not null or empty
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Logger for ErrorModel
        private readonly ILogger<ItemNotFoundModel> _logger;

        /// <summary>
        /// ErrorModel constructor; sets _logger to inputted ILogger<ErrorModel>
        /// </summary>
        public ItemNotFoundModel(ILogger<ItemNotFoundModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// updates RequestId
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}