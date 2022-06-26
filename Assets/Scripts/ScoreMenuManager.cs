using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMenuManager : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField]
    private ScoreGroupController bubbleGameGroup;
    [SerializeField]
    private ScoreGroupController bridgeGameGroup;
    [SerializeField]
    private ScoreGroupController windowGameGroup;
    [SerializeField]
    private ScoreGroupController orchestraGameGroup;
    void Start()
    {
        FindObjectOfType<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        SavesManager savesManager = SavesManager.getInstance();

        KeyValuePair<string, int> best = savesManager.getBubbleGameMaxScore();
        bubbleGameGroup.setTexts(savesManager.getBubbleGameScore().ToString(), best.Value.ToString(), best.Key);

        best = savesManager.getBridgeGameMaxScore();
        bridgeGameGroup.setTexts(savesManager.getBridgeGameScore().ToString(), best.Value.ToString(), best.Key);

        best = savesManager.getWindowGameMaxScore();
        windowGameGroup.setTexts(savesManager.getWindowGameScore().ToString(), best.Value.ToString(), best.Key);

        best = savesManager.getOrchestraGameMaxScore();
        orchestraGameGroup.setTexts(savesManager.getOrchestraGameScore().ToString(), best.Value.ToString(), best.Key);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
