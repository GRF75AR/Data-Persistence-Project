using UnityEngine;
using System.IO;
using System;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;
    public string BestScorePlayer;
    public int BestScore;
    public string PlayerName;


    private void Awake()
    {
        GetSingleton();
        LoadBestPlayer();
    }

    private void GetSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void SaveBestPlayer(int points)
    {
        SaveData data = new SaveData();
        data.BestScorePlayer = PlayerName;
        data.BestScore = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    internal void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScorePlayer = data.BestScorePlayer;
            BestScore = data.BestScore;
        }
    }

    internal void SaveBestScore(int m_Points)
    {
        if(m_Points > BestScore)
        {
            SaveBestPlayer(m_Points);
        }
    }
}


[System.Serializable]
class SaveData
{
    public string BestScorePlayer;
    public int BestScore;
}