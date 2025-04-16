using System;

namespace Mirror.Transports.Edgegap.EdgegapLobby.Models
{
    // https://docs.edgegap.com/docs/lobby/functions#functions
    [Serializable]
    public struct ListLobbiesResponse
    {
        public int count;
        public LobbyBrief[] data;
    }
}
