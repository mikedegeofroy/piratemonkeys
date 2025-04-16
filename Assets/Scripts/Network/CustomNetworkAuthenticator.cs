using Mirror;
using UnityEngine;

namespace Network
{
    public class CustomNetworkAuthenticator : NetworkAuthenticator
    {
        public override void OnClientAuthenticate()
        {
            string username = PlayerPrefs.GetString("username", "Guest");

            // Send username to server as connection payload
            NetworkClient.connection.authenticationData = username;
            base.OnClientAuthenticate();
        }

        public override void OnServerAuthenticate(NetworkConnectionToClient conn)
        {
            conn.authenticationData = conn.authenticationData; // trust client value for now
            ServerAccept(conn); // always accept for now
        }
    }
}