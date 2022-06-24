using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavesManager
{
    private static SavesManager instance;
    private static readonly string BaseFolder = "Saves";

    private Dictionary<string, int> bubbleGameScores;
    private Dictionary<string, int> bridgeGameScores;
    private Dictionary<string, int> windowGameScores;
    private Dictionary<string, int> orchestraGameScores;

    private SavesManager()
    {
        if (!Directory.Exists(BaseFolder))
            Directory.CreateDirectory(BaseFolder);

        bubbleGameScores = deserialize("bubbleGameScores.dat");
        bridgeGameScores = deserialize("bridgeGameScores.dat");
        windowGameScores = deserialize("windowGameScores.dat");
        orchestraGameScores = deserialize("orchestraGameScores.dat");
    }

    private Dictionary<string, int> deserialize(string name)
    {
        string filepath = Path.Combine(BaseFolder, name);
        Dictionary<string, int> dict = new Dictionary<string,int>();
        if(!File.Exists(filepath))
            return dict;
        using (var sr = new StreamReader(filepath))
        {
            string line1,line2;
            while(!sr.EndOfStream)
            {
                line1 = sr.ReadLine();
                line2 = sr.ReadLine();
                dict.Add(line1, int.Parse(line2));
            }
        }

        return dict;
    }

    private void serialize(Dictionary<string, int> data, string name)
    {
        using (var sw = new StreamWriter(Path.Combine(BaseFolder, name), false))
        {
            foreach(KeyValuePair<string, int> kvp in data)
            {
                sw.WriteLine(kvp.Key);
                sw.WriteLine(kvp.Value);
            }
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
        serialize(bubbleGameScores, "bubbleGameScores.dat");
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
        serialize(bridgeGameScores, "bridgeGameScores.dat");
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
        serialize(windowGameScores, "windowGameScores.dat");
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
        serialize(orchestraGameScores, "orchestraGameScores.dat");
    }

    private int getScore(Dictionary<string,int> scores)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!scores.ContainsKey(username))
            return 0;
        return scores[username];
    }

    public int getBubbleGameScore()
    {
        return getScore(bubbleGameScores);
    }

    public int getBridgeGameScore()
    {
        return getScore(bridgeGameScores);
    }

    public int getWindowGameScore()
    {
        return getScore(windowGameScores);
    }

    public int getOrchestraGameScore()
    {
        return getScore(orchestraGameScores);
    }

    private KeyValuePair<string, int> getMaxScore(Dictionary<string, int> scores)
    {
        KeyValuePair<string, int> res = new KeyValuePair<string, int>("------",0);
        foreach(KeyValuePair<string,int> pair in scores)
        {
            if (pair.Value > res.Value)
                res = pair;
        }
        return res;
    }

    public KeyValuePair<string,int> getBubbleGameMaxScore()
    {
        return getMaxScore(bubbleGameScores);
    }

    public KeyValuePair<string, int> getBridgeGameMaxScore()
    {
        return getMaxScore(bridgeGameScores);
    }

    public KeyValuePair<string, int> getWindowGameMaxScore()
    {
        return getMaxScore(windowGameScores);
    }

    public KeyValuePair<string, int> getOrchestraGameMaxScore()
    {
        return getMaxScore(orchestraGameScores);
    }
}
