using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private int isSoundInitialized;
    private float volume;

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
        Debug.Log(volume);
    }
    public void PlayBridgeGame()
    {
        PlayerPrefs.SetFloat("Volume",volume);
        SceneManager.LoadScene("BridgeGame");
    }
    public void PlayBubbleGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Bubble game");
    }
    public void PlayWindowGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Orchestral game");
    }
    public void PlayOrchestralGame()
    {
        PlayerPrefs.SetFloat("Volume", volume);
        SceneManager.LoadScene("Window Game");
    }

    public void ExitGame()
    {
        Debug.Log("Exit completed");
        Application.Quit();
    }

    public void IncreaseVolume()
    {
        if(volume < 1)
        {
            volume += 0.1f;
        }
    }
    public void DecreaseVolume()
    {
        if (volume > 0)
        {
            volume -= 0.1f;
        }
        if(volume < 0.1f)
        {
            volume = 0;
        }
    }
}
