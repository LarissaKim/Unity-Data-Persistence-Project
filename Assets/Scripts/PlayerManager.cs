using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string PlayerName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestScore();
    }

    public void SaveNewPlayer(string name)
    {
        // Handle shy players
        if (name == "")
        {
            PlayerName = "Guest";
        }
        else
        {
            PlayerName = name;
        }

        // Allows multiple players on same computer (but overwrites existing save file)
        BestScore = 0;
    }

    [System.Serializable]
    class BestScoreData
    {
        public string PlayerName;
        public int BestScore;
    }

    public void SaveBestScore(int score)
    {
        // Enable immediate UI update
        BestScore = score;

        BestScoreData data = new BestScoreData();
        data.PlayerName = PlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        string saveFilePath = Application.persistentDataPath + "savefile.json";

        File.WriteAllText(saveFilePath, json);
    }

    public void LoadBestScore()
    {
        string saveFilePath = Application.persistentDataPath + "savefile.json";

        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);

            BestScoreData data = JsonUtility.FromJson<BestScoreData>(json);

            PlayerName = data.PlayerName;
            BestScore = data.BestScore;
        }
    }
}
