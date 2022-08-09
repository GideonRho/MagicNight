using MagicNight.Services;
using MagicNight.States;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MagicNight.Pages
{
    public class DownloadModel : PageModel
    {

        private IWebHostEnvironment Environment { get; }
        private CardService CardService { get; }
        private StateContainer StateContainer { get; }

        public DownloadModel(IWebHostEnvironment environment, CardService cardService, StateContainer stateContainer)
        {
            Environment = environment;
            CardService = cardService;
            StateContainer = stateContainer;
        }

        public IActionResult OnGet(string key)
        {
            //    var name = CardService.Save(StateContainer.DownloadDeck).Result;
            
            var filePath = $"{Environment.WebRootPath}/downloads/{key}";

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/force-download", "deck.dek");
        }
    }
}