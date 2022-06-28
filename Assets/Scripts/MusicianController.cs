using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class which controls the musician in orchestral game
/// </summary>
public class MusicianController : MonoBehaviour
{
    [SerializeField]
    private Sprite silent;
    [SerializeField]
    private Sprite playingMusic;
    [SerializeField]
    private AudioSource music;
    public int id;
    private OrchestraLevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    /// <summary>
    /// Start is called before the first frame update
    /// finds the levelManager and spritew renderer
    /// sets the volume to music of the musician
    /// </summary>
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("Volume");
        levelManager = FindObjectOfType<OrchestraLevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    /// <summary>
    /// IEnumerator to start the coroutime and make musician play the music
    /// </summary>
    /// <returns>time to play music</returns>
    public IEnumerator PlayMusic()
    {
        levelManager.IsScreenActive = false;
        spriteRenderer.sprite = playingMusic;
        music.Play();
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = silent;
        levelManager.IsScreenActive = true;
    }
    /// <summary>
    /// on mouse clicked makes the musician play music
    /// </summary>
    private void OnMouseDown()
    {
        StartCoroutine(levelManager.CheckChoosenMusician(id));
    }
}
