using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// class which shows the rules for the particular game
/// </summary>
public class RuleScreenController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ruleText;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject ruleScreen;
    [SerializeField]
    private GameObject lifeHolder;
    /// <summary>
    /// Start is called before the first frame update
    /// sets pause button and lifeHolder to be unactive and showt the rule creen
    /// </summary>
    void Start()
    {
        Time.timeScale = 0;
        ruleText.text = GetRuleText();
        pauseButton.SetActive(false);
        ruleScreen.SetActive(true); 
        lifeHolder.SetActive(false);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>particular rule for the game</returns>
    private string GetRuleText()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Bubble game":
                return "�� ��� ���������� � ����������� ���������� ������� �� �����!����� �� ���, ��� ���� ��������� � �� ������ �� ���������� ��������.";
            case "BridgeGame":
                return "�������� ������ �������� �����!����� �� ����� � ��������� �����������, ��� ������� � ��� ����� � ���������� ���.";
            case "Orchestral game":
                return "�����'������ ����������� ����� �� �������� ��, ���������� �� ���������.";
            case "Window Game":
                return "������ �������� ���� ��������, ���� ����� ����������, ��� ������� ��� �����.";
                
            default: return "";
        }
        
    }
    /// <summary>
    /// removes the rules screen and starts the game
    /// </summary>
    public void StartTheGame()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        ruleScreen.SetActive(false);
        lifeHolder.SetActive(true);
    }
}
