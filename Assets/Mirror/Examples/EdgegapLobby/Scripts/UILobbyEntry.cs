using Mirror.Transports.Edgegap.EdgegapLobby.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror.Examples.EdgegapLobby.Scripts
{
    public class UILobbyEntry : MonoBehaviour
    {
        public Button JoinButton;
        public Text Name;
        public Text PlayerCount;

        private LobbyBrief _lobby;
        private UILobbyList _list;
        private void Awake()
        {
            JoinButton.onClick.AddListener(() =>
            {
                _list.Join(_lobby);
            });
        }

        public void Init(UILobbyList list, LobbyBrief lobby, bool active = true)
        {
            gameObject.SetActive(active && lobby.is_joinable);
            JoinButton.interactable = lobby.available_slots > 0;
            _list = list;
            _lobby = lobby;
            Name.text = lobby.name;
            PlayerCount.text = $"{lobby.player_count}/{lobby.capacity}";
        }
    }

}
