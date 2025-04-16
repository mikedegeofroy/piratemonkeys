using System;

namespace Mirror.Transports.Edgegap.EdgegapLobby.Models
{
    // https://docs.edgegap.com/docs/lobby/functions#updating-a-lobby
    [Serializable]
    public struct LobbyUpdateRequest
    {
        public int capacity;
        public bool is_joinable;
        public string[] tags;
    }
}
