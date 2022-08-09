using System;
using System.Collections.Generic;
using MagicNight.Models.Enums;
using MagicNight.Models.Filters;

namespace MagicNight.Models.Data.Generating
{
    public class DeckGeneratorData
    {

        public CommanderPair Commander { get; set; }

        public DeckTypeDistribution Distribution { get; set; } = new();
        public DeckCurve Curve { get; set; } = new();
        public DeckWeights Weights { get; set; } = new();
        
        private int CreatureCount { get; set; }
        private int NonCreatureCount { get; set; }

        public DeckGeneratorData Prepare()
        {
            var random = new Random();
            
            Distribution.Prepare(random);
            Curve.Prepare(random, Distribution.Creatures.Value + Distribution.NonCreatures.Value);
            Weights.Prepare(random);

            CreatureCount = Distribution.Creatures.Value;
            NonCreatureCount = Distribution.NonCreatures.Value;

            return this;
        }

        public ManaBaseFilter ManaBase()
        {
            return new ManaBaseFilter(this);
        }

        public IEnumerable<CardSlot> Build()
        {

            int low = Curve.Low.Value;
            int medium = Curve.Medium.Value;
            int high = Curve.High.Value;

            foreach (var cardSlot in Split(low, 0, 3))
                yield return cardSlot;

            foreach (var cardSlot in Split(medium, 4, 6))
                yield return cardSlot;
            
            foreach (var cardSlot in Split(high, 7, 99))
                yield return cardSlot;
            
        }

        private IEnumerable<CardSlot> Split(int amount, int minCmc, int maxCmc)
        {
            yield return ForCreature(amount / 2, minCmc, maxCmc);
            yield return ForNonCreature(amount - amount / 2, minCmc, maxCmc);
        } 

        private CardSlot ForCreature(int amount, int minCmc, int maxCmc)
            => new CardSlot(Commander, amount, CardTypes.Creature, minCmc, maxCmc)
                .SetWeights(Weights);

        private CardSlot ForNonCreature(int amount, int minCmc, int maxCmc)
            => new CardSlot(Commander, amount, 
                CardTypes.Artifact | CardTypes.Enchantment | CardTypes.Instant
                | CardTypes.Instant | CardTypes.Planeswalker | CardTypes.Sorcery
                , minCmc, maxCmc)
                .SetWeights(Weights);

    }
}