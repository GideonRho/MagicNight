using MagicNight.Models.Database.Cards;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Filters
{
    public class EdhGenFilter
    {
        
        public Card Commander { get; set; }

        public int Lands { get; set; } = 37;
        public int BasicLands { get; set; } = 12;
        public int Ramp2 { get; set; } = 8;
        public int Ramp3 { get; set; } = 4;

        public int Creatures { get; set; } = 30;
        public int Artifacts { get; set; } = 5;
        public int Spells { get; set; } = 15;

        public ManaBaseFilter ManaFilter()
        {
            ManaBaseFilter filter = new();
            if (Commander.Colors.HasFlag(Colors.White)) filter.ColorFilter.White = true;
            if (Commander.Colors.HasFlag(Colors.Blue)) filter.ColorFilter.Blue = true;
            if (Commander.Colors.HasFlag(Colors.Black)) filter.ColorFilter.Black = true;
            if (Commander.Colors.HasFlag(Colors.Red)) filter.ColorFilter.Red = true;
            if (Commander.Colors.HasFlag(Colors.Green)) filter.ColorFilter.Green = true;
            filter.Lands = Lands;
            filter.BasicLands = BasicLands;
            filter.Artifacts2 = Ramp2;
            filter.Artifacts3 = Ramp3;
            return filter;
        }

    }
}