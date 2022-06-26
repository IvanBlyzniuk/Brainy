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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetNameFromInput(string s)
    {
        name = s;
    }
    public void Proceed()
    {
        if (!string.IsNullOrWhiteSpace(inputField.text))
        {
            userName = inputField.text;
            Debug.Log(userName);
            PlayerPrefs.SetString("currentUserName", userName);
            Debug.Log(PlayerPrefs.GetString("currentUserName"));
            SceneManager.LoadScene("Main Menu");
        }
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}
