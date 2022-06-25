using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private int isSoundInitialized;
    private float volume;
    [SerializeField]
    private TextMeshProUGUI volumeText;
    [SerializeField]
    private GameObject stopPlayingScreen;
    void Start()
    {
        volume = PlayerPrefs.GetFloat("Volume");
        isSoundInitialized = PlayerPrefs.GetInt("IsSoundInitialized");
        //Debug.Log(isSoundInitialized);
        if(isSoundInitialized == 0)
        {
            volume = 0.5f;
            PlayerPrefs.SetInt("IsSoundInitialized", 1);
        }
        volumeText.text = ((int)(volume*10)).ToString();
        Debug.Log(volume);
        if (Time.realtimeSinceStartup > 10)
        {
            stopPlayingScreen.SetActive(true);
        }
    }
    public void PlayBridgeGame()
    {
        if (!stopPlayingScreen.activeSelf)
        {

        
        PlayerPrefs.SetFloat("Volume",volume);
        SceneManager.LoadScene("BridgeGame");
        }
    }
    public void PlayBubbleGame()
    {
        if (!stopPlayingScreen.activeSelf)
        {
            PlayerPrefs.SetFloat("Volume", volume);
            SceneManager.LoadScene("Bubble game");
        }
    }
    public void PlayWindowGame()
    {
        if (!stopPlayingScreen.activeSelf)
        {
            PlayerPrefs.SetFloat("Volume", volume);
            SceneManager.LoadScene("Window Game");
        }
    }
    public void PlayOrchestralGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Orchestral game");
        
    }
    public void GoToScoreScreen()
    {
        if (!stopPlayingScreen.activeSelf)
        {
            SceneManager.LoadScene("Score Menu");
        }
    }

    public void ExitGame()
    {
        if (!stopPlayingScreen.activeSelf)
        {
            Debug.Log("Exit completed");
            Application.Quit();
        }
    }

    public void IncreaseVolume()
    {
        if (!stopPlayingScreen.activeSelf)
        {
            if (volume < 1)
            {
                volume += 0.1f;
                volumeText.text = ((int)(volume * 10)).ToString();
            }
        }
    }
    public void DecreaseVolume()
    {
        if (!stopPlayingScreen.activeSelf)
        {
            if (volume > 0)
            {
                volume -= 0.1f;
                volumeText.text = ((int)(volume * 10)).ToString();
            }
            if (volume < 0.1f)
            {
                volume = 0;
                volumeText.text = ((int)(volume * 10)).ToString();
            }
        }
    }
}
