using System.Collections.Generic;
using MagicNight.Models.Database.Profiles;

namespace MagicNight.Models.Data.Drafts;

public class CreateDraftData
{

    public class Entry
    {
        public PackType PackType { get; set; }

        public Entry(PackType packType)
        {
            PackType = packType;
        }
    }
    
    public int PickTime { get; set; } = 120;
    public List<Entry> Packs { get; set; } = new();

    public void Add(PackType type)
    {
        Packs.Add(new Entry(type));
    }
    
}