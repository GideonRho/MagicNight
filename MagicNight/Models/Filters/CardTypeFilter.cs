using System;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Filters
{
    public class CardTypeFilter
    {
        
        public bool Land { get; set; }
        public bool Creature { get; set; }
        public bool Artifact { get; set; }
        public bool Enchantment { get; set; }
        public bool Planeswalker { get; set; }
        public bool Instant { get; set; }
        public bool Sorcery { get; set; }
        public bool Legendary { get; set; }

        public CardTypes Flags()
        {
            CardTypes t = 0;
            foreach (var value in Enum.GetValues<CardTypes>())
            {
                if (IsSet(value))
                    t |= value;
            }
            return t;
        }

        public bool IsSet(CardTypes cardTypes) => cardTypes switch
        {
            CardTypes.Land => Land,
            CardTypes.Creature => Creature,
            CardTypes.Artifact => Artifact,
            CardTypes.Enchantment => Enchantment,
            CardTypes.Planeswalker => Planeswalker,
            CardTypes.Instant => Instant,
            CardTypes.Sorcery => Sorcery,
            CardTypes.Legendary => Legendary,
            CardTypes.Basic => false,
            CardTypes.Snow => false,
            _ => throw new ArgumentOutOfRangeException(nameof(cardTypes), cardTypes, null)
        };

    }
}