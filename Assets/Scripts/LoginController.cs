using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    private string name;
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
            name = inputField.text;
            Debug.Log(name);
            PlayerPrefs.SetString("currentUserName", name);
            Debug.Log(PlayerPrefs.GetString("currentUserName"));
            SceneManager.LoadScene("Main Menu");
        }
        
    }
}
