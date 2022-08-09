using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Models.Database.Cards;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class ImportService
    {

        private DatabaseContext Database { get; set; }

        public ImportService(DatabaseContext database)
        {
            Database = database;
        }

        public async Task<IEnumerable<Card>> FromStringList(IEnumerable<string> list)
        {
            var tasks = list
                .Select(FromString)
                .Where(c => c != null);
            return await Task.WhenAll(tasks);;
        }

        public Task<Card> FromString(string s)
        {
            string[] split = s.Split(' ', 3);
            
            if (split.Length != 3) return null;
            if (!int.TryParse(split[0], out var count)) return null;
            
            string info = split[1];
            string name = split[2];

            return Database.Cards
                .FirstOrDefaultAsync(c => c.Name == name);
        }
        
    }
}