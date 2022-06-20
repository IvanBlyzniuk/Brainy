using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public string sceneName;
    public TextMeshProUGUI scoreText;
    private LevelUIController levelUIController;
    // Start is called before the first frame update
    void Start()
    {
        levelUIController = FindObjectOfType<LevelUIController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndGame()
    {
        scoreText.text = "��� �������:" + levelUIController.score;
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    
}
