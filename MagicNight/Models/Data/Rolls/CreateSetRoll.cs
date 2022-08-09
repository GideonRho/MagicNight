using System;
using MagicNight.Models.Database.Rolls;

namespace MagicNight.Models.Data.Rolls
{
    public class CreateSetRoll
    {

        public SetRoll SetRoll { get; set; } = new(DateTime.Now);
        public int Packs { get; set; } = 3;
        
    }
}