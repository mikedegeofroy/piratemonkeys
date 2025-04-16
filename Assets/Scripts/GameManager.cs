using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void SetUsername(string username)
    {
        Debug.Log($"Received username from JS: {username}");
        PlayerPrefs.SetString("username", username);
    }
}