using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// class which controls the music in main menu
/// </summary>
public class MainMusicController : MonoBehaviour
{
    private static MainMusicController instance = null;
    public static MainMusicController Instance
    {
        get { return instance; }
    }
    /// <summary>
    /// make the music to continue when we move between main menu and score scenes
    /// </summary>
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
