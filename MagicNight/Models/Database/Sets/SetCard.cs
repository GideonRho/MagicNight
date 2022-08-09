using System.ComponentModel.DataAnnotations.Schema;
using MagicNight.Misc;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Enums;
using MagicNight.Models.Scryfall;

namespace MagicNight.Models.Database.Sets;

public class SetCard
{
    
    public int Id { get; set; }
    
    public string SetName { get; set; }
    public string CardName { get; set; }

    [ForeignKey("SetName")]
    public Set Set { get; set; }
    [ForeignKey("CardName")]
    public Card Card { get; set; }
    public Rarity Rarity { get; set; }
    
    public string Thumbnail { get; set; }
    public string Image { get; set; }

    public SetCard()
    {
    }

    public SetCard(ScryfallCard scryfallCard)
    {
        SetName = scryfallCard.Set.ToUpper();
        CardName = scryfallCard.Name;
        Rarity = RarityHelper.FromString(scryfallCard.Rarity);
        Thumbnail = scryfallCard.GetThumbnail();
        Image = scryfallCard.GetImage();
    }
}