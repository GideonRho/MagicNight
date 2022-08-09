using System;
using System.Linq;
using MagicNight.Misc;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Scryfall
{
    [Serializable]
    public class CardFaces
    {
        
        public string Name { get; set; }
        public string[] Colors { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        // ReSharper disable once InconsistentNaming
        public ImageUris Image_Uris { get; set; }
        
        public Colors ColorsFlags
            => (Colors)Colors
                .Select(CardHelper.ColorFromString)
                .Distinct()
                .Sum(c => (int) c);
        
    }
}