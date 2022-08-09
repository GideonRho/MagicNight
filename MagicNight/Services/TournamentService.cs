using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Models.Data;
using MagicNight.Models.Data.Tournaments;
using MagicNight.Models.Database.Profiles;
using MagicNight.Models.Database.Tournaments;
using MagicNight.Models.Database.Tournaments.Values;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class TournamentService
    {

        private DatabaseContext Database { get; }

        public TournamentService(DatabaseContext database)
        {
            Database = database;
        }

        public async Task<TournamentData> Create(Lobby lobby)
        {
            return TournamentData.RoundRobin(lobby.Users);
        }
        
        public async Task<Tournament> Get(int id)
        {
            return await Database.Tournaments
                .Include(t => t.Participants)
                .ThenInclude(p => p.Profile)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddParticipant(Tournament tournament, Profile profile)
        {
            tournament.Participants.Add(new TournamentParticipant(tournament, profile));
            Database.Tournaments.Update(tournament);
            await Database.SaveChangesAsync();
        }
        
        public async Task Create(Tournament tournament)
        {
            Database.Tournaments.Add(tournament);
            await Database.SaveChangesAsync();
        }

        public IQueryable<Tournament> All()
        {
            return Database.Tournaments;
        }

    }
}