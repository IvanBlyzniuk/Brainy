using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavesManager
{
    private static SavesManager instance;
    private static readonly string BaseFolder = Path.Combine("Saves");

    private Dictionary<string, int> bubbleGameScores;
    private Dictionary<string, int> bridgeGameScores;
    private Dictionary<string, int> windowGameScores;
    private Dictionary<string, int> orchestraGameScores;

    private SavesManager()
    {
        if (!Directory.Exists(BaseFolder))
        {
            Directory.CreateDirectory(BaseFolder);
            bubbleGameScores = new Dictionary<string, int> ();
            bridgeGameScores = new Dictionary<string, int>();
            windowGameScores = new Dictionary<string, int>();
            orchestraGameScores = new Dictionary<string, int>();
        }
        else
        {
            bubbleGameScores = deserialize(Path.Combine(BaseFolder, "bubleGameScores.dat"));
            bridgeGameScores = deserialize(Path.Combine(BaseFolder, "bridgeGameScores.dat"));
            windowGameScores = deserialize(Path.Combine(BaseFolder, "windowGameScores.dat"));
            orchestraGameScores = deserialize((Path.Combine(BaseFolder, "orchestraGameScores.dat")));
        }
        if (bubbleGameScores.Keys.Count > 0)
            Debug.Log(PlayerPrefs.GetString("currentUserName") + " " + bubbleGameScores[PlayerPrefs.GetString("currentUserName")]);
    }

    private Dictionary<string, int> deserialize(string name)
    {
        string stringObj;
        string filepath = Path.Combine(BaseFolder, name);
        using (var sr = new StreamReader(filepath))
        {
            stringObj = sr.ReadToEnd();
        }

        return JsonUtility.FromJson<Dictionary<string, int>>(stringObj);
    }

    private void serialize(Dictionary<string, int> data, string name)
    {
        string stringObj = JsonUtility.ToJson(data);
        using (var sw = new StreamWriter(Path.Combine(BaseFolder, name), false))
        {
            sw.Write(stringObj);
        }
    }

    public static SavesManager getInstance()
    {
        if (instance == null)
            instance = new SavesManager();
        return instance;
    }

    public void saveBubbleGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if(!bubbleGameScores.ContainsKey(username))
        {
            bubbleGameScores.Add(username, score);
            return;
        }
        int oldScore = bubbleGameScores[username];
        if (score > oldScore)
            bubbleGameScores[username] = score;
    }



    public void saveBridgeGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!bridgeGameScores.ContainsKey(username))
        {
            bridgeGameScores.Add(username, score);
            return;
        }
        int oldScore = bridgeGameScores[username];
        if (score > oldScore)
            bridgeGameScores[username] = score;
    }

    public void saveWindowGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!windowGameScores.ContainsKey(username))
        {
            windowGameScores.Add(username, score);
            return;
        }
        int oldScore = windowGameScores[username];
        if (score > oldScore)
            windowGameScores[username] = score;
    }

    public void saveOrchestraGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!orchestraGameScores.ContainsKey(username))
        {
            orchestraGameScores.Add(username, score);
            return;
        }
        int oldScore = orchestraGameScores[username];
        if (score > oldScore)
            orchestraGameScores[username] = score;
    }

    ~SavesManager()
    {
        serialize(bubbleGameScores, "bubbleGameScores.dat");
        serialize(bridgeGameScores, "bridgeGameScores.dat");
        serialize(windowGameScores, "windowGameScores.dat");
        serialize(orchestraGameScores, "orchestraGameScores.dat");
    }
}
