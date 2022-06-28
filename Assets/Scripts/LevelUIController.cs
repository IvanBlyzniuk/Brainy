using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// class which controls the main UI components
/// </summary>
public class LevelUIController : MonoBehaviour
{
   // public ILevelManager levelManager;
    private int lifesCount = 3;
    private GameOverController gameOverController;
    private int score = 0;
    private AudioSource loseLifeSound;
    [SerializeField]
    private Image life1;
    [SerializeField]
    private Image life2;
    [SerializeField]
    private Image life3;

    /// <summary>
    /// Start is called before the first frame update
    /// finds GameOverController and AudioSource of the life losing sound
    /// sets the volume to the loseLifeSound
    /// </summary>
    void Start()
    {
        gameOverController = FindObjectOfType<GameOverController>();
        loseLifeSound = GetComponent<AudioSource>();
        loseLifeSound.volume = PlayerPrefs.GetFloat("Volume");
    }
    /// <summary>
    /// adds some value to the sound
    /// </summary>
    /// <param name="val">value to add</param>
    public void AddScore(int val)
    {
        score+=val;
    }
    /// <summary>
    /// make player lose one life
    /// </summary>
    public void MakeMistake()
    {
        loseLifeSound.Play();
        lifesCount--;
        UpdateLifeMeter();
    }
    /// <summary>
    /// calls the EndGame mehod of the gameOverController
    /// </summary>
    public void LoseTheGame()
    {
        gameOverController.EndGame();
    }
    /// <summary>
    ///
    /// </summary>
    /// <returns>the current count of player's lives</returns>
    public int GetLifesCount()
    {
        return lifesCount;
    }
    /// <summary>
    /// updates the visual representation of the player's lives
    /// </summary>
    private void UpdateLifeMeter()
    {
        if (lifesCount == 2)
        {
            Destroy(life1);
        }
        else if(lifesCount == 1)
        {
            Destroy(life2);
        }
        else if (lifesCount == 0)
        {
            Destroy(life3);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>current score</returns>
    public int GetScore()
    {
        return score;
    }
}
