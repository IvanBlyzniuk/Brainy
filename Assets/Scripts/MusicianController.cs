using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("Volume");
        levelManager = FindObjectOfType<OrchestraLevelManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator PlayMusic()
    {
        levelManager.IsScreenActive = false;
        spriteRenderer.sprite = playingMusic;
        music.Play();
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = silent;
        levelManager.IsScreenActive = true;
    }

    private void OnMouseDown()
    {
        StartCoroutine(levelManager.CheckChoosenMusician(id));
    }
}
