using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    /// <summary>
    /// Start is called before the first frame update
    /// sets the volume to the game music
    /// </summary>
    void Start()
    {
        GetComponent<AudioSource>().volume=PlayerPrefs.GetFloat("Volume");
    }
}
