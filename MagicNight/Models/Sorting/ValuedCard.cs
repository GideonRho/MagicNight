using System;
using MagicNight.Misc;
using MagicNight.Models.Data.Generating;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Filters;

namespace MagicNight.Models.Sorting
{
    public class ValuedCard
    {
        
        public Card Card { get; }
        public float Value { get; }

        public ValuedCard(Card card, float value)
        {
            Card = card;
            Value = value;
        }

        public ValuedCard(Card card, EdhGenFilter filter, Random random)
        {
            Card = card;
            Value = 1;
            Value += card.Colors.Count() * 0.1f;
            if (card.SharesMinorType(filter.Commander.MinorTypes))
                Value += 0.0f;
            
            Value *= (float) random.NextDouble();
            
            if (card.HasSynergy(filter.Commander.Synergies))
                Value += 1.6f;

        }

        public ValuedCard(Card card, CardSlot cardSlot, Random random)
        {
            Card = card;
            Value = 100;

            Value += card.Colors.Count() * 10f;
            if (card.HasSynergy(cardSlot.Synergies))
                Value += cardSlot.SynergyWeight;
            
            if (card.SharesMinorType(cardSlot.MinorTypes))
                Value += cardSlot.MinorTypesWeight;
            
            Value *= (float) random.NextDouble();
            
        }
    }
}