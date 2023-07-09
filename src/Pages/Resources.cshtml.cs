using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuickKitchen.WebSite.Pages
{

    /// <summary>
    /// Ckass for resource page of the website .
    /// </summary>
    public class ResourcesModel : PageModel
    {

        // logger for ResourcesModel
        private readonly ILogger<ResourcesModel> _logger;

        /// <summary>
        /// REsourcesModel constructor; sets _logger to inputted ILogger<REsourcesModel>
        /// </summary>
        /// <param name="logger"></param>
        public ResourcesModel(ILogger<ResourcesModel> logger)
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