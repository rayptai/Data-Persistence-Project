using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager Instance;

    private static string SAVE_FILE_NAME = "savefile.json";

    public string Name;
    public HighScores HighScores;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScores();
    }

    [System.Serializable]
    class SaveData
    {
        public HighScores HighScores;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SaveHighScores()
    {
        Debug.Log(Application.persistentDataPath);

        SaveData data = new SaveData();
        data.HighScores = HighScores;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/" + SAVE_FILE_NAME, json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/" + SAVE_FILE_NAME;
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScores = data.HighScores;
        }
    }
}
