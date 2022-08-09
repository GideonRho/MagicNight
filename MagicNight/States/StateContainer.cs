using System;
using System.Collections.Generic;
using MagicNight.Logic;
using MagicNight.Models.Data;

namespace MagicNight.States
{
    public class StateContainer
    {
        private string _guestName;

        public string GuestName
        {
            get => _guestName;
            set
            {
                _guestName = value;
                NotifyStateChanged();
            }
        }

        private Dictionary<Lobby.EType, LobbyInstance> Lobbies { get; } = new();

        public bool InLobby(Lobby.EType type) => Lobbies.ContainsKey(type);
        public LobbyInstance LobbyInstance(Lobby.EType type)
        {
            Lobbies.TryGetValue(type, out var value);
            return value;
        }

        public void Join(LobbyInstance instance)
        {
            if (instance == null) return;
            Lobbies[instance.Lobby.Type] = instance;
            NotifyStateChanged();
        }

        public bool HasName => !string.IsNullOrEmpty(GuestName);

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}