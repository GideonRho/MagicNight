using System;

namespace MagicNight.Models.Enums
{
    [Flags]
    public enum CardTypes
    {
        Land = 1, Creature = 2, Artifact = 4, Enchantment = 8, Planeswalker = 16, Instant = 32, Sorcery = 64, Legendary = 128, Basic = 256, Snow = 512
    }
}