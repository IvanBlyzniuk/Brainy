using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicianController : MonoBehaviour
{
    public Sprite silent;
    public Sprite playingMusic;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator PlayMusic()
    {
        GetComponent<SpriteRenderer>().sprite = playingMusic;
        music.Play();
        yield return new WaitForSeconds(1.1f);
        GetComponent<SpriteRenderer>().sprite = silent;
    }
}
