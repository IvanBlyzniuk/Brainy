using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Singleton class that manages saves for all of the games
/// </summary>
public class SavesManager
{
    private static SavesManager instance;
    private static readonly string BaseFolder = Path.Combine(Application.dataPath,"Saves");
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

    /// <summary>
    /// Deserializes dictionary of specified name from the disc reading key-value pairs from consecutive lines
    /// </summary>
    /// <param name="name">Name of the file should be in .dat format</param>
    /// <returns>Dictionary of nicknames to maxscores of each user</returns>
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
    /// <summary>
    /// Serializes dictionary to the disc writing key-value pairs in new lines (one line for key and one for value)
    /// </summary>
    /// <param name="data"></param>
    /// <param name="name"></param>
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

    /// <summary>
    /// Returns the instance of this class and creates it if needed
    /// </summary>
    /// <returns></returns>
    public static SavesManager getInstance()
    {
        if (instance == null)
            instance = new SavesManager();
        return instance;
    }

    /// <summary>
    /// Saves and serializes bubble game score
    /// </summary>
    /// <param name="score"></param>
    public void saveBubbleGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if(!bubbleGameScores.ContainsKey(username))
        {
            bubbleGameScores.Add(username, score);
            serialize(bubbleGameScores, "bubbleGameScores.dat");
            return;
        }
        int oldScore = bubbleGameScores[username];
        if (score > oldScore)
            bubbleGameScores[username] = score;
        serialize(bubbleGameScores, "bubbleGameScores.dat");
    }

    /// <summary>
    /// Saves and serializes bridge game score
    /// </summary>
    /// <param name="score"></param>
    public void saveBridgeGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!bridgeGameScores.ContainsKey(username))
        {
            bridgeGameScores.Add(username, score);
            serialize(bridgeGameScores, "bridgeGameScores.dat");
            return;
        }
        int oldScore = bridgeGameScores[username];
        if (score > oldScore)
            bridgeGameScores[username] = score;
        serialize(bridgeGameScores, "bridgeGameScores.dat");
    }

    /// <summary>
    /// Saves and serializes window game score
    /// </summary>
    /// <param name="score"></param>
    public void saveWindowGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!windowGameScores.ContainsKey(username))
        {
            windowGameScores.Add(username, score);
            serialize(windowGameScores, "windowGameScores.dat");
            return;
        }
        int oldScore = windowGameScores[username];
        if (score > oldScore)
            windowGameScores[username] = score;
        serialize(windowGameScores, "windowGameScores.dat");
    }

    /// <summary>
    /// Saves and serializes orchestra game score
    /// </summary>
    /// <param name="score"></param>
    public void saveOrchestraGameScore(int score)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!orchestraGameScores.ContainsKey(username))
        {
            orchestraGameScores.Add(username, score);
            serialize(orchestraGameScores, "orchestraGameScores.dat");
            return;
        }
        int oldScore = orchestraGameScores[username];
        if (score > oldScore)
            orchestraGameScores[username] = score;
        serialize(orchestraGameScores, "orchestraGameScores.dat");
    }

    /// <summary>
    /// Returns the max score of current user (taken from PlayerPrefs) from scpecified dictionary
    /// </summary>
    /// <param name="scores">dictionary to look through</param>
    /// <returns>max score of current user</returns>
    private int getScore(Dictionary<string,int> scores)
    {
        string username = PlayerPrefs.GetString("currentUserName");
        if (!scores.ContainsKey(username))
            return 0;
        return scores[username];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Max score of current user (taken from PlayerPrefs) in bubble game</returns>
    public int getBubbleGameScore()
    {
        return getScore(bubbleGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Max score of current user (taken from PlayerPrefs) in bridge game</returns>
    public int getBridgeGameScore()
    {
        return getScore(bridgeGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Max score of current user (taken from PlayerPrefs) in window game</returns>
    public int getWindowGameScore()
    {
        return getScore(windowGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Max score of current user (taken from PlayerPrefs) in orchestra game</returns>
    public int getOrchestraGameScore()
    {
        return getScore(orchestraGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="scores"></param>
    /// <returns>Pair of name of user with max score in specified dictionary and corresponding score</returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Pair of name of user with max score in bubble game and corresponding score</returns>
    public KeyValuePair<string,int> getBubbleGameMaxScore()
    {
        return getMaxScore(bubbleGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Pair of name of user with max score in bridge game and corresponding score</returns>
    public KeyValuePair<string, int> getBridgeGameMaxScore()
    {
        return getMaxScore(bridgeGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Pair of name of user with max score in window game and corresponding score</returns>
    public KeyValuePair<string, int> getWindowGameMaxScore()
    {
        return getMaxScore(windowGameScores);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Pair of name of user with max score in orchestra game and corresponding score</returns>
    public KeyValuePair<string, int> getOrchestraGameMaxScore()
    {
        return getMaxScore(orchestraGameScores);
    }
}
