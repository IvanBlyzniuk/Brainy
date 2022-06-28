using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    private string userName;
    [SerializeField]
    private TMP_InputField inputField;
    /// <summary>
    /// sets the player name from the input field
    /// </summary>
    /// <param name="s"></param>
    public void GetNameFromInput(string s)
    {
        name = s;
    }
    /// <summary>
    /// saves the current user name and loads the main menu
    /// </summary>
    public void Proceed()
    {
        if (!string.IsNullOrWhiteSpace(inputField.text))
        {
            userName = inputField.text;
            PlayerPrefs.SetString("currentUserName", userName);
            SceneManager.LoadScene("Main Menu");
        }
        
    }
    /// <summary>
    /// quits the game
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
