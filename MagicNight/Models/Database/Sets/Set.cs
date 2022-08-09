using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MagicNight.Models.Database.Cards;
using MtgApiManager.Lib.Model;

namespace MagicNight.Models.Database.Sets
{
    public class Set
    {
        
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }

        public SetSettings Settings { get; set; }
        
        public List<SetCard> Cards { get; set; }

        public Set()
        {
        }

        public Set(ISet set)
        {
            Code = set.Code;
            Name = set.Name;
            Type = set.Type;
            ReleaseDate = DateTime.Parse(set.ReleaseDate);
        }

        public string Logo => $"http://mtgen.net/{Code}/images/logo-word.png";
        public override string ToString() => Name;

    }
}