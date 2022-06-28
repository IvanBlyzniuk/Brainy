using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// class which controls the gameOver screen
/// </summary>
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
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        levelUIController = FindObjectOfType<LevelUIController>();
    }
    /// <summary>
    /// ends the game,stos the time, sets pause button to be inactive and shows the gameOver screen
    /// </summary>
    public void EndGame()
    {
        pauseButton.SetActive(false);
        scoreCount.text = levelUIController.GetScore().ToString();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    /// <summary>
    /// sets the timeScale to 1 and reloads the current scene
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /// <summary>
    /// sets the timeScale to 1 and loads the main menu scene
    /// </summary>
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    
}
