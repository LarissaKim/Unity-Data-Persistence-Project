using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerNameInput;

    public void StartNew()
    {
        Debug.Log("Setting player name");
        SavePlayerNameInput();

        Debug.Log("Loading scene");
        SceneManager.LoadScene(1);
    }

    public void SavePlayerNameInput()
    {
        PlayerManager.Instance.SavePlayerName(PlayerNameInput.text);

        Debug.Log(PlayerManager.Instance.PlayerName);
    }
}
