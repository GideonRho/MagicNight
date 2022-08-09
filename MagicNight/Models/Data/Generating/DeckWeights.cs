using System;
using MagicNight.Models.Types;

namespace MagicNight.Models.Data.Generating
{
    public class DeckWeights
    {

        public RandomInt MinorTypes { get; set; } = new();
        public RandomInt Synergies { get; set; } = new();
        public RandomInt Keywords { get; set; } = new();

        public void Prepare(Random random)
        {

            Prepare(random, MinorTypes);
            Prepare(random, Synergies);
            Prepare(random, Keywords);
            
        }

        private void Prepare(Random random, RandomInt ri)
        {
            if (ri.Type == RandomInt.EType.Auto)
                ri.Value = 100;
            if (ri.Type == RandomInt.EType.Random)
                ri.Value = random.Next(0, 200);
        }
        
    }
}