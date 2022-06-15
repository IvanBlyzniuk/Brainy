using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicianController : MonoBehaviour
{
    public Sprite silent;
    public Sprite playingMusic;
    public AudioSource music;
    public int id;
    private OrchestraLevelManager levelManager;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<OrchestraLevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator PlayMusic()
    {
        levelManager.isScreenActive = false;
        spriteRenderer.sprite = playingMusic;
        music.Play();
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = silent;
        levelManager.isScreenActive = true;
    }

    private void OnMouseDown()
    {
        StartCoroutine(levelManager.CheckChoosenMusician(id));
    }
}
