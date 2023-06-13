using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerNameInput;

    // Pre-fill input field with name from save file
    void Start()
    {
        if (PlayerManager.Instance.PlayerName != null)
        {
            PlayerNameInput.text = PlayerManager.Instance.PlayerName;
        }
    }

    public void StartNew()
    {
        // Allows multiple players on same computer (but overwrites existing save file)
        if (PlayerNameInput.text != PlayerManager.Instance.PlayerName)
        {
            PlayerManager.Instance.SaveNewPlayer(PlayerNameInput.text);
        }

        SceneManager.LoadScene(1);
    }
}
