using System.Collections.Generic;
using System.Linq;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Data
{
    public class CommanderPair
    {
        
        public Card Card { get; set; }
        public Card Partner { get; set; }

        public CommanderPair(Card card)
        {
            Card = card;
        }

        public CommanderPair(Card card, Card partner)
        {
            Card = card;
            Partner = partner;
        }

        public Colors Colors()
        {
            if (Partner != null)
                return Partner.Colors | Card.Colors;
            return Card.Colors;
        }

        public List<CardMinorType> MinorTypes()
        {
            if (Partner != null)
                return Card.MinorTypes
                    .Concat(Partner.MinorTypes)
                    .Distinct()
                    .ToList();
            return Card.MinorTypes;
        }
        
        public List<CardSynergy> Synergies()
        {
            if (Partner != null)
                return Card.Synergies
                    .Concat(Partner.Synergies)
                    .Distinct()
                    .ToList();
            return Card.Synergies;
        }

        public List<CardKeyword> Keywords()
        {
            if (Partner != null)
                return Card.Keywords
                    .Concat(Partner.Keywords)
                    .Distinct()
                    .ToList();
            return Card.Keywords;
        }
        
    }
}