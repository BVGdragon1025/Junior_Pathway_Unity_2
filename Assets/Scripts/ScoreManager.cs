using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score;
    public string playerName;

    public int highScore;
    public string highScorePlayer;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();

    }

    [System.Serializable]
    class GameData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveHighScore(int score, string player)
    {
        GameData data = new GameData();

        data.playerName = player;
        data.playerScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            highScore = data.playerScore;
            highScorePlayer = data.playerName;
        }
    }

}
