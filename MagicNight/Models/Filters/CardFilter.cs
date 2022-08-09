namespace MagicNight.Models.Filters
{
    public class CardFilter
    {

        public ColorFilter ColorFilter { get; set; } = new();
        public CardTypeFilter TypeFilter { get; set; } = new();

        public int MinCost { get; set; } = 0;
        public int MaxCost { get; set; } = 16;
        public int MinPower { get; set; } = 0;
        public int MaxPower { get; set; } = 99;
        public int MinToughness { get; set; } = 0;
        public int MaxToughness { get; set; } = 99;

    }
}