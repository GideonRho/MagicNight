using System;
using System.Collections.Generic;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Enums;
// ReSharper disable InconsistentNaming

namespace MagicNight.Models.Scryfall
{
    [Serializable]
    public class ScryfallCard
    {
        
        public string Name { get; set; }
        public string Lang { get; set; }
        public string Type_Line { get; set; }
        public string[] Colors { get; set; }
        public float Cmc { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public ImageUris Image_Uris { get; set; }
        public List<AllPart> All_Parts { get; set; }
        public string Uri { get; set; }
        public string Oracle_Text { get; set; }
        public string Released_At { get; set; }
        public string Rarity { get; set; }
        
        public CardFaces[] Card_Faces { get; set; }
        public string[] Produced_Mana { get; set; }
        public List<string> Keywords { get; set; }

        public Dictionary<string, string> Legalities { get; set; }
        public string Set { get; set; }
        public string Collector_Number { get; set; }
        public string Edhrec_Rank { get; set; }
        public Prices Prices { get; set; }
        
        public Colors ColorsFlags
            => (Colors)Colors
                .Select(CardHelper.ColorFromString)
                .Distinct()
                .Sum(c => (int) c);

        public Colors ProducedManaFlags
            => (Colors)Produced_Mana
                .Select(CardHelper.ColorFromString)
                .Distinct()
                .Sum(c => (int) c);

        public string GetThumbnail()
        {
            return GetImageUris() != null ? GetImageUris().Small : "";
        }

        public string GetImage()
        {
            return GetImageUris() != null ? GetImageUris().Border_Crop : "";
        }
        
        public ImageUris GetImageUris()
        {
            if (Image_Uris != null) return Image_Uris;
            if (Card_Faces is { Length: > 0 } && Card_Faces[0].Image_Uris != null)
                return Card_Faces[0].Image_Uris;
            return null;
        }
        
    }
}