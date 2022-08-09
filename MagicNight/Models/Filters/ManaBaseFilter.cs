using MagicNight.Models.Data.Generating;

namespace MagicNight.Models.Filters
{
    public class ManaBaseFilter
    {

        public ColorFilter ColorFilter { get; set; } = new();
        
        public int Lands { get; set; }
        public int BasicLands { get; set; }
        public int Artifacts2 { get; set; }
        public int Artifacts3 { get; set; }

        public ManaBaseFilter()
        {
            Lands = 24;
        }

        public ManaBaseFilter(DeckGeneratorData data)
        {
            ColorFilter = new ColorFilter(data.Commander.Colors());
            Lands = data.Distribution.Lands.Value;
            BasicLands = data.Distribution.Lands.Value / 2;
            Artifacts2 = data.Distribution.Ramp.Value / 2;
            Artifacts3 = data.Distribution.Ramp.Value - (data.Distribution.Ramp.Value / 2);
        }
        
    }
}