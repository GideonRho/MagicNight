using System.IO;
using System.Threading.Tasks;
using MagicNight.Models.Data;
using Microsoft.AspNetCore.Hosting;

namespace MagicNight.Services;

public class DownloadService
{
    
    private IWebHostEnvironment Environment { get; }

    public DownloadService(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public async Task Save(BaseDeck deck)
    {

        var lines = CardService.ExportLines(deck.Cards);
        await File.WriteAllLinesAsync(DeckPath(deck.Id), lines);

    }
    
    public string DeckLink(string deckId) => $"download/{deckId}"; 
    public string DeckLink(int deckId) => $"download/{deckId}";
    public string TemporaryLink(string name) => $"download/{name}";
    
    public string DeckPath(int deckId) => $"{DownloadDirectory}/{deckId}";
    public string DeckPath(string deckId) => $"{DownloadDirectory}/{deckId}";
    public string TemporaryDeckPath(string name) => $"{DownloadDirectory}/{name}";
    
    private string DownloadDirectory => $"{Environment.WebRootPath}/downloads";

}