using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI scoreCount;
    [SerializeField]
    private GameObject pauseButton;
    
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
        pauseButton.SetActive(false);
        scoreCount.text = levelUIController.GetScore().ToString();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    
}
