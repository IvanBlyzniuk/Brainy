using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public float volume = 0.5f;
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
