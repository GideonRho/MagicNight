using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Data;
using MagicNight.Helpers;
using MagicNight.Logic;
using MagicNight.Models.Data;
using MagicNight.Models.Data.Drafts;
using MagicNight.Models.Database.Drafts;
using Microsoft.EntityFrameworkCore;

namespace MagicNight.Services
{
    public class DraftService
    {
        
        private MtgApiService MtgApi { get; }
        private DatabaseContext Database { get; }
        private PackService PackService { get; }

        public DraftService(MtgApiService mtgApi, DatabaseContext database, PackService packService)
        {
            MtgApi = mtgApi;
            Database = database;
            PackService = packService;
        }

        public DraftData Create(LobbyInstance instance) => Create(instance.Lobby.Users, instance.CreateDraftData);

        public DraftData Create(List<string> users, CreateDraftData data)
        {
            var players = users
                .Select(u => new Player(u, data.Packs.Select(p => MtgApi.OpenPack(p.PackType))))
                .ToList();

            for (int i = 0; i < players.Count; i++)
            {
                players[i].Next = players[(i + 1).Modulo(players.Count)];
                players[i].Previous = players[(i - 1).Modulo(players.Count)];
            }
            
            var result = new DraftData(players, data.PickTime);

            return result;
        }
        
        public IQueryable<Draft> Query
            => Database.Drafts
                .Include(d => d.Packs)
                .ThenInclude(p => p.Cards)
                .ThenInclude(c => c.Card)
                .Include(d => d.Profiles)
                .ThenInclude(p => p.Profile)
                .Include(d => d.Profiles)
                .ThenInclude(p => p.Previous)
                .Include(d => d.Profiles)
                .ThenInclude(p => p.Next);

        public IQueryable<Draft> Active
            => Query.Where(d => d.State == Draft.EState.Ongoing);

        public async Task<Draft> Get(int id)
            => await Query.FirstOrDefaultAsync(d => d.Id == id);

        // public async Task<Draft> Create(CreateDraftData data)
        // {
        //     var draft = new Draft(data.PickTime);
        //     var profiles = data.Profiles;
        //     
        //     for (int pi = 0; pi < data.Profiles.Count; pi++)
        //     {
        //         var profile = profiles[pi];
        //         var next = profiles[IntHelper.Modulo(pi + 1, profiles.Count)];
        //         var previous = profiles[IntHelper.Modulo(pi - 1, profiles.Count)];
        //         var draftProfile = new DraftProfile(draft, profile, next, previous);
        //         draft.Profiles.Add(draftProfile);
        //         int rotation = 0;
        //         foreach (var setPack in data.Sets)
        //         {
        //             for (int i = 0; i < setPack.Amount; i++)
        //                 draft.Packs.Add(new DraftPack(draft, rotation++, draftProfile,
        //                     await MtgApi.Booster(setPack.Set)));
        //         }
        //     }
        //
        //     await Database.Drafts.AddAsync(draft);
        //     await Database.SaveChangesAsync();
        //     
        //     return draft;
        // }

        public async Task Delete(Draft draft)
        {
            Database.DraftProfiles.RemoveRange(draft.Profiles);
            Database.DraftPackCards.RemoveRange(draft.Packs.SelectMany(p => p.Cards));
            Database.DraftPacks.RemoveRange(draft.Packs);
            Database.Drafts.Remove(draft);
            await Database.SaveChangesAsync();
        }

    }
}