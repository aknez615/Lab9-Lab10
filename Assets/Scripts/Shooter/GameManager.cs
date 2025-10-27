using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private string scoreFilePath;
    private string positionsFilePath;

    private void Awake()
    {
        scoreFilePath = Path.Combine(Application.persistentDataPath, "score.dat");
        positionsFilePath = Path.Combine(Application.persistentDataPath, "positions.json");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            SaveGame();
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            LoadGame();
        }
    }

    public void SaveGame()
    {
        SaveScore();
        SavePositions();
        Debug.Log("Game saved");
    }

    public void LoadGame()
    {
        LoadScore();
        LoadPositions();
        Debug.Log("Game loaded");
    }

    private void SaveScore()
    {
        using (FileStream stream = File.Open(scoreFilePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, scoreManager.Score);
        }
        Debug.Log($"Saved Score: {scoreManager.Score}");
    }

    private void LoadScore()
    {
        if (File.Exists(scoreFilePath))
        {
            using (FileStream stream = File.Open(scoreFilePath, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                int loadedScore = (int)formatter.Deserialize(stream);
                scoreManager.SetScore(loadedScore);
            }
            Debug.Log($"Loaded Score: {scoreManager.Score}");
        }
    }

    private void SavePositions()
    {
        var saveables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        Dictionary<string, object> positions = new();

        foreach (var s in saveables)
        {
            if (s is ISaveable saveable)
            {
                positions[s.name] = saveable.CaptureState();
            }
        }

        string json = JsonUtility.ToJson(new SerializationWrapper(positions), true);
        File.WriteAllText(positionsFilePath, json);
    }

    private void LoadPositions()
    {
        if (File.Exists(positionsFilePath)) return;

        string json = File.ReadAllText(positionsFilePath);
        var wrapper = JsonUtility.FromJson<SerializationWrapper>(json);

        var saveables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach (var s in saveables)
        {
            if (s is ISaveable saveable && wrapper.data.TryGetValue(s.name, out var state))
            {
                saveable.RestoreState(state);
            }
        }
    }

    [System.Serializable]
    private class SerializationWrapper
    {
        public Dictionary<string, object> data;

        public SerializationWrapper(Dictionary<string, object> data)
        {
            this.data = data;
        }
    }
}
