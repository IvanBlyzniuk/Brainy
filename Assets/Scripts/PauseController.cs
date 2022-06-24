using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private GameObject pauseButton;

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
        LevelUIController levelUIController = FindObjectOfType<LevelUIController>();
        Time.timeScale = 1f;
        switch (SceneManager.GetActiveScene().name)
        {
            case "Bubble game":
                SavesManager.getInstance().saveBubbleGameScore(levelUIController.GetScore()) ;
                break;
            case "BridgeGame":
                SavesManager.getInstance().saveBridgeGameScore(levelUIController.GetScore());
                break;
            case "Orchestral game":
                SavesManager.getInstance().saveOrchestraGameScore(levelUIController.GetScore());
                break;
            case "Window Game":
                SavesManager.getInstance().saveWindowGameScore(levelUIController.GetScore());
                break;
        }
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
