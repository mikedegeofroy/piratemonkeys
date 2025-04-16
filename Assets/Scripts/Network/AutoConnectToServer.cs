using Mirror;
using Mirror.SimpleWeb;
using UnityEngine;

namespace Network
{
    public class AutoConnectToServer : MonoBehaviour
    {
        [SerializeField] private string serverAddress = "server-build.fly.dev";
        [SerializeField] private ushort serverPort = 443;

        void Start()
        {
            // Get reference to SimpleWebTransport
            if (NetworkManager.singleton.transport is SimpleWebTransport transport)
            {
                transport.port = serverPort;
            }
            else
            {
                Debug.LogError("SimpleWebTransport not found! Make sure it's assigned in the NetworkManager.");
            }

// #if UNITY_WEBGL && !UNITY_EDITOR
            // WebGL build (e.g. browser): connect to public host (e.g. Render)
            NetworkManager.singleton.networkAddress = serverAddress;
// #else
//         // In Editor or desktop build: connect to localhost for local testing
//         NetworkManager.singleton.networkAddress = "127.0.0.1";
// #endif

            NetworkManager.singleton.StartClient();
            Debug.Log($"StartClient() called. Connecting to {NetworkManager.singleton.networkAddress}:{serverPort}");
        }
    }
}