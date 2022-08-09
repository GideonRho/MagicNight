using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MagicNight.Logic;
using MagicNight.Models.Data;

namespace MagicNight.Services;

public class LobbyService
{

    public IServiceProvider ServiceProvider { get; }
    
    private ConcurrentDictionary<string, LobbyInstance> Instances { get; } = new();

    public LobbyService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public LobbyInstance Access(string key)
    {
        if (key == null) return null;
        if (!Instances.TryGetValue(key, out var instance)) return null;
        return instance;
    }

    public LobbyInstance Host(Lobby.EType type)
    {
        var key = Guid.NewGuid().ToString();
        var instance = new LobbyInstance(this, key, type);
        Instances.TryAdd(key, instance);
        return instance;
    }

    public LobbyInstance Host(Lobby.EType type, IEnumerable<string> users)
    {
        var lobby = Host(type);
        lobby.Lobby.Users.AddRange(users);
        return lobby;
    }
    
}