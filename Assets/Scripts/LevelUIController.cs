using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIController : MonoBehaviour
{
   // public ILevelManager levelManager;
    private int lifesCount = 3;
    private int score;
    public Image life1;
    public Image life2;
    public Image life3;
    // Start is called before the first frame update
    void Start()
    {
        
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
        lifesCount--;
        UpdateLifeMeter();
    }
    //TODO remind Vania + make end game screen
    public void LoseTheGame()
    {
        SceneManager.LoadScene("Main Menu");
       
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
}
