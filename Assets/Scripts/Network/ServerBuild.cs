using Mirror.Core;
using UnityEngine;

namespace Network
{
    public class ServerBuild : MonoBehaviour
    {
        void Start()
        {
            if (Application.isBatchMode)
            {
                Debug.Log("Starting Mirror headless server...");
                NetworkManager.singleton.StartServer();
            }
        }
    }
}