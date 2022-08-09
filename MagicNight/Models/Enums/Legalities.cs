using System;

namespace MagicNight.Models.Enums
{
    [Flags]
    public enum Legalities
    {
        Standard = 1, Historic = 2, Modern = 4, Legacy = 8, Pauper = 16, Commander = 32, Brawl = 64
    }
}