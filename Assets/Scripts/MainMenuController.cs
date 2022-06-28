using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// class which controls the main menu 
/// </summary>
public class MainMenuController : MonoBehaviour
{
    private int isSoundInitialized;
    private float volume;
    [SerializeField]
    private TextMeshProUGUI volumeText;
    [SerializeField]
    private GameObject stopPlayingScreen;
    /// <summary>
    /// Start is called before the first frame update
    /// initializes the sonds' volume 
    /// </summary>
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        isSoundInitialized = PlayerPrefs.GetInt("IsSoundInitialized");
        if (isSoundInitialized == 0)
        {
            volume = 0.5f;
            PlayerPrefs.SetInt("IsSoundInitialized", 1);
        }
        volumeText.text = (Mathf.Round(volume * 10)).ToString();
        if (Time.realtimeSinceStartup > 1800)
        {
            stopPlayingScreen.SetActive(true);
        }
        FindObjectOfType<AudioSource>().volume=volume;
    }
    /// <summary>
    /// loads the bridge game scene 
    /// </summary>
    public void PlayBridgeGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("BridgeGame");
    }
    /// <summary>
    /// loads the bubble game scene
    /// </summary>
    public void PlayBubbleGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Bubble game");
    }
    /// <summary>
    /// loads the window game scene
    /// </summary>
    public void PlayWindowGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Window Game");
    }
    /// <summary>
    /// loads the orchestral game scene
    /// </summary>
    public void PlayOrchestralGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Orchestral game");

    }
    /// <summary>
    /// loads the score info scene 
    /// </summary>
    public void GoToScoreScreen()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Score Menu");
    }
    /// <summary>
    /// exits the game
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// increases the volume
    /// </summary>
    public void IncreaseVolume()
    {
        if (volume < 1)
        {
            volume += 0.1f;
            volumeText.text = (Mathf.Round(volume * 10)).ToString();
            FindObjectOfType<AudioSource>().volume = volume;
        }
    }
    /// <summary>
    /// decreases the volume
    /// </summary>
    public void DecreaseVolume()
    {
        if (volume > 0)
        {
            volume -= 0.1f;
            volumeText.text = (Mathf.Round(volume * 10)).ToString();
        }
        if (volume < 0.1f)
        {
            volume = 0;
            volumeText.text = (Mathf.Round(volume * 10)).ToString();
        }
        FindObjectOfType<AudioSource>().volume = volume;
    }
    /// <summary>
    /// set the stopPlayingScreen to b inactive
    /// </summary>
    public void ContinueRegardless()
    {
        stopPlayingScreen.SetActive(false);
    }
}
