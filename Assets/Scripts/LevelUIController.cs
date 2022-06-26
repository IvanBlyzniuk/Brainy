using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    // Start is called before the first frame update
    void Start()
    {
        gameOverController = FindObjectOfType<GameOverController>();
        loseLifeSound = GetComponent<AudioSource>();
        loseLifeSound.volume = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void AddScore(int val)
    {
        score+=val;
    }

    public void MakeMistake()
    {
        loseLifeSound.Play();
        lifesCount--;
        UpdateLifeMeter();
    }
    //TODO remind Vania + make end game screen
    public void LoseTheGame()
    {

        gameOverController.EndGame();
    }
    public int GetLifesCount()
    {
        return lifesCount;
    }
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
    public int GetScore()
    {
        return score;
    }
}
