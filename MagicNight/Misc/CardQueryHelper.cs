using System.Linq;
using MagicNight.Models.Data.Generating;
using MagicNight.Models.Database.Cards;

namespace MagicNight.Misc
{
    public static class CardQueryHelper
    {

        public static IQueryable<Card> Filter(this IQueryable<Card> query, CardSlot slot)
        {
            return query
                .Where(c => slot.Types.HasFlag(c.Types))
                .Where(c => slot.Colors.HasFlag(c.Colors))
                .Where(c => c.Cost >= slot.MinCmc && c.Cost <= slot.MaxCmc);
        }

    }
}