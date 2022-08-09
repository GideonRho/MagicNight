using System.Collections.Generic;
using MagicNight.Models.Database.Cards;
using MagicNight.Models.Enums;

namespace MagicNight.Models.Data.Generating
{
    public class CardSlot
    {
        
        public int Amount { get; set; }
        public Colors Colors { get; set; }
        public CardTypes Types { get; set; }
        public int MinCmc { get; set; }
        public int MaxCmc { get; set; }
        
        public List<CardMinorType> MinorTypes { get; set; } 
        public List<CardSynergy> Synergies { get; set; }
        public List<CardKeyword> Keywords { get; set; }

        public int SynergyWeight { get; set; } = 100;
        public int MinorTypesWeight { get; set; } = 100;
        public int KeywordsWeight { get; set; } = 100;
        
        public CardSlot(CommanderPair commander, int amount, CardTypes types, int minCmc, int maxCmc)
        {
            Amount = amount;
            Types = types;
            MinCmc = minCmc;
            MaxCmc = maxCmc;

            Colors = commander.Colors();
            MinorTypes = commander.MinorTypes();
            Synergies = commander.Synergies();
            Keywords = commander.Keywords();

        }

        public CardSlot SetWeights(DeckWeights weights)
        {
            SynergyWeight = weights.Synergies.Value;
            MinorTypesWeight = weights.MinorTypes.Value;
            KeywordsWeight = weights.Keywords.Value;
            return this;
        }

    }
}