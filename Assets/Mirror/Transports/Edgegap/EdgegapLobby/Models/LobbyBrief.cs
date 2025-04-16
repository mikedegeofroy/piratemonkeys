using System;

namespace Mirror.Transports.Edgegap.EdgegapLobby.Models
{
    // Brief lobby data, returned by the list function
    [Serializable]
    public struct LobbyBrief
    {
        public string lobby_id;
        public string name;
        public bool is_joinable;
        public bool is_started;
        public int player_count;
        public int capacity;
        public int available_slots => capacity - player_count;
        public string[] tags;
    }
}
