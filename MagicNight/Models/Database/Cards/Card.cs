using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Enums;
using MagicNight.Models.Scryfall;

namespace MagicNight.Models.Database.Cards
{
    public class Card
    {
        
        [Key]
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Power { get; set; }
        public int Toughness { get; set; }

        public Colors Colors { get; set; }
        public CardTypes Types { get; set; }
        public Colors ProducedMana { get; set; }
        public Legalities Legalities { get; set; }
        
        public string Thumbnail { get; set; }
        public string Image { get; set; }

        public string Uri { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string ReleaseDate { get; set; }

        public int Rank { get; set; }
        public float Price { get; set; }
        
        public List<CardMinorType> MinorTypes { get; set; }
        public List<CardSynergy> Synergies { get; set; }
        public List<CardKeyword> Keywords { get; set; }
        
        public string PartnerString { get; set; }
        
        public Card Partner { get; set; }

        public List<Commander> Commanders { get; set; }
        
        public Card()
        {
        }

        public Card(ScryfallCard scryfallCard)
        {
            Name = scryfallCard.Name;
            Power = ParseStat(scryfallCard.Power);
            Toughness = ParseStat(scryfallCard.Toughness);
            Cost = (int) scryfallCard.Cmc;
            Uri = scryfallCard.Uri;
            Text = scryfallCard.Oracle_Text;
            ReleaseDate = scryfallCard.Released_At;
            Id = $"{scryfallCard.Set.ToUpper()}:{scryfallCard.Collector_Number}";
            MinorTypes = new List<CardMinorType>();

            Rank = ParseStat(scryfallCard.Edhrec_Rank);
            if (scryfallCard.Prices != null)
                Price = ParseFloat(scryfallCard.Prices.Eur);
            
            if (scryfallCard.Keywords != null)
                Keywords = scryfallCard.Keywords
                    .Select(s => new CardKeyword(this, s))
                    .ToList();

            var types = CardHelper.CardTypesFromString(scryfallCard.Type_Line).ToList();
            foreach (var s in types)
            {
                var type = CardHelper.GetCardType(s);
                if (type.HasValue)
                    Types |= type.Value;
                else
                    MinorTypes.Add(new CardMinorType(this, s));
            }

            if (scryfallCard.Colors != null)
                Colors = scryfallCard.ColorsFlags;

            if (scryfallCard.Produced_Mana != null)
                ProducedMana = scryfallCard.ProducedManaFlags;

            Thumbnail = scryfallCard.GetThumbnail();
            Image = scryfallCard.GetImage();

            if (scryfallCard.Card_Faces is {Length: > 0})
            {
                foreach (var face in scryfallCard.Card_Faces.Where(f => f.Colors != null))
                    Colors |= face.ColorsFlags;
            }

            if (scryfallCard.Legalities != null)
            {
                foreach (var legality in Enum.GetValues<Legalities>())
                {
                    string name = legality.ToString().ToLower();
                    if (scryfallCard.Legalities.ContainsKey(name) && scryfallCard.Legalities[name] == "legal")
                        Legalities |= legality;
                }
            }

            PartnerString = SearchPartner(scryfallCard);

        }

        public void BuildPartner(IEnumerable<Card> cards)
        {
            if (PartnerString == null) return;
            Partner = cards.First(c => c.Name == PartnerString);
        }
        
        private string SearchPartner(ScryfallCard card)
        {
            if (card.Keywords == null) return null;
            if (card.All_Parts == null) return null;
            if (!card.Keywords.Contains("Partner with")) return null;

            var partner = card.All_Parts
                .Where(p => p.Component == "combo_piece" && p.Name != card.Name)
                .Select(p => p.Name)
                .FirstOrDefault();

            return partner;
        }
        
        public bool IsCommander() => Commanders.Count > 0;

        private static int ParseStat(string stat)
        {
            if (stat == null) return 0;
            if (int.TryParse(stat, out var i))
                return i;
            return 0;
        }
        
        private static float ParseFloat(string value)
        {
            if (value == null) return 0;
            if (float.TryParse(value, out var f))
                return f;
            return 0;
        }
        
        public void UpdateSynergies(IReadOnlyCollection<string> keys)
        {
            Synergies = CalculateSynergies(keys)
                .Select(k => new CardSynergy(this, k))
                .ToList();
        }
        
        private IEnumerable<string> CalculateSynergies(IReadOnlyCollection<string> keys)
        {
            if (Text == null) yield break;
            var words = Text.ToLower().Split(' ');
            foreach (var word in words)
            {
                if (keys.All(k => k != word)) continue;
                yield return word;
            }
        }

        public bool SharesMinorType(List<CardMinorType> minorTypes)
        {
            return MinorTypes.Any(t => minorTypes.Any(ot => ot.Type == t.Type));
        }
        
        public bool HasSynergy(List<CardSynergy> synergies)
        {
            return Synergies.Any(s => synergies.Any(os => os.Type == s.Type));
        }
        
        public string ExportString()
        {
            return $"1 {Name}";
        }

        public string SideboardString() => $"SB: {ExportString()}";

    }
}