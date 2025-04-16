using Mirror;
using Ship;

namespace Network
{
    public class CustomNetworkManager : NetworkManager
    {
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            var player = Instantiate(playerPrefab);

            var username = conn.authenticationData as string ?? "Guest";
            player.GetComponent<ShipController>().username = username;

            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }
}