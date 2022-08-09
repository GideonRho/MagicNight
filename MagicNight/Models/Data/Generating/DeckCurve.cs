using System;
using MagicNight.Models.Types;

namespace MagicNight.Models.Data.Generating
{
    public class DeckCurve
    {

        public RandomInt Low { get; set; } = new();
        public RandomInt Medium { get; set; } = new();
        public RandomInt High { get; set; } = new();

        public void Prepare(Random random, int amount)
        {

            if (Low.Type == RandomInt.EType.Auto)
                Low.Value = amount / 3;
            if (Low.Type == RandomInt.EType.Random)
                Low.Value = random.Next(0, amount);

            int rest = amount - Low.Value;

            if (Medium.Type == RandomInt.EType.Auto)
                Medium.Value = amount / 3;
            if (Medium.Type == RandomInt.EType.Random)
                Medium.Value = random.Next(0, rest);

            rest -= Medium.Value;

            if (High.Type == RandomInt.EType.Auto)
                High.Value = rest;
            if (High.Type == RandomInt.EType.Random)
                High.Value = random.Next(0, rest);
            
        }
        
    }
}