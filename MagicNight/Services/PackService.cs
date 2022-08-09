using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicNight.Models.Data.Drafts;
using MagicNight.Models.Database.Cards;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MagicNight.Services;

public class PackService
{
    
    private IServiceProvider ServiceProvider { get; }
    
    private List<PackType> PackTypes { get; set; }

    public PackService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        PackTypes = GetTypes().Result.ToList();
    }

    private async Task<IEnumerable<PackType>> GetTypes()
    {
        using var scope = ServiceProvider.CreateScope();
        var setService = scope.ServiceProvider.GetRequiredService<SetService>();

        var sets = await setService.Query
            .Where(s => s.Settings.CanRoll)
            .ToListAsync();

        return sets.Select(s => new PackType(s));
    }

    public IEnumerable<PackType> All => PackTypes;

}