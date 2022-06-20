using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        pauseButton.SetActive(false);
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void VolumeUp()
    {
        foreach (AudioSource a in FindObjectsOfType<AudioSource>())
        {
            if (a.volume < 1f)
                a.volume += 0.1f;
            if (a.volume > 1f)
                a.volume = 1f;
        }
        PlayerPrefs.SetFloat("Volume", FindObjectOfType<AudioSource>().volume);
    }
    public void VolumeDown()
    {
        foreach (AudioSource a in FindObjectsOfType<AudioSource>())
        {
            if (a.volume > 0f)
                a.volume -= 0.1f;
            if (a.volume < 0f)
                a.volume = 0f;
        }
        PlayerPrefs.SetFloat("Volume", FindObjectOfType<AudioSource>().volume);
    }
}
