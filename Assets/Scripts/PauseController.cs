using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller for pause screen
/// </summary>
public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private TextMeshProUGUI volumeNumber;

    // Start is called before the first frame update
    void Start()
    {
        volumeNumber.text = (Mathf.Round(PlayerPrefs.GetFloat("Volume") * 10)).ToString();
    }

    /// <summary>
    /// Pauses the game and shows pause screen
    /// </summary>
    public void Pause()
    {
        pauseButton.SetActive(false);
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Resumes the game and disables the pause screen
    /// </summary>
    public void Resume()
    {
        pauseButton.SetActive(true);
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }


    /// <summary>
    /// Changes the scene to main menu and saves score of the current game as if it was finished
    /// </summary>
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
    /// <summary>
    /// Increases the volume by 10%, saves the value to PlayerPrefs and updates it for all objects that have AudioSource on the current scene
    /// </summary>
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
        volumeNumber.text = (Mathf.Round(PlayerPrefs.GetFloat("Volume") * 10)).ToString();
    }

    /// <summary>
    /// Reduces the volume by 10%, saves the value to PlayerPrefs and updates it for all objects that have AudioSource on the current scene
    /// </summary>
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
        
        volumeNumber.text = (Mathf.Round(PlayerPrefs.GetFloat("Volume") * 10)).ToString();
    }
}
