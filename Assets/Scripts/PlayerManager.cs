using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string PlayerName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    

    public void SavePlayerName(string name)
    {
        if (name == "")
        {
            PlayerName = "Guest";
        }
        else
        {
            PlayerName = name;
        }
    }
}
