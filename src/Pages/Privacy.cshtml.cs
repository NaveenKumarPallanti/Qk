using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Class for the privacy page of the website
    /// </summary>
    public class PrivacyModel : PageModel
    {

        // logger for PrivacyModel
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// PrivacyModel constructor; sets _logger to inputted ILogger<PrivacyModel>
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnGet function does not do anything
        /// </summary>
        public void OnGet()
        {
        }
    }
}