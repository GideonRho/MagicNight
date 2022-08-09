using System;

namespace MagicNight.Models.Scryfall
{
    [Serializable]
    public class ImageUris
    {
        public string Small { get; set; }
        // ReSharper disable once InconsistentNaming
        public string Border_Crop { get; set; }
    }
}