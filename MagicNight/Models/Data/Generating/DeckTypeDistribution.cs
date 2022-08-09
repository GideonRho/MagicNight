using System;
using MagicNight.Models.Types;

namespace MagicNight.Models.Data.Generating
{
    public class DeckTypeDistribution
    {

        public RandomInt Creatures { get; set; } = new();
        public RandomInt NonCreatures { get; set; } = new();
        public RandomInt Lands { get; set; } = new();
        public RandomInt Ramp { get; set; } = new();

        public void Prepare(Random random)
        {

            if (Lands.Type == RandomInt.EType.Auto) Lands.Value = 37;
            if (Lands.Type == RandomInt.EType.Random) Lands.Value = random.Next(33, 42);

            if (Ramp.Type == RandomInt.EType.Auto) Ramp.Value = 12;
            if (Ramp.Type == RandomInt.EType.Random) Ramp.Value = random.Next(0, 20);

            int total = Lands.Value + Ramp.Value;

            if (Creatures.Type == RandomInt.EType.Auto)
                Creatures.Value = (100 - total) / 2;
            if (Creatures.Type == RandomInt.EType.Random)
                Creatures.Value = random.Next(0, 100 - total);

            total += Creatures.Value;
            
            if (NonCreatures.Type == RandomInt.EType.Auto)
                NonCreatures.Value = 100 - total;
            if (NonCreatures.Type == RandomInt.EType.Random)
                NonCreatures.Value = random.Next(0, 100 - total);

        }
        
    }

}