using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Controller for group of TextMeshProUGUI that represents your/max score in a single game
/// </summary>
public class ScoreGroupController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI yourScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreNameText;

    /// <summary>
    /// Sets texts to corresponding TextMeshProUGUIs
    /// </summary>
    /// <param name="yourScore">Score of the current player</param>
    /// <param name="bestScore">Best score</param>
    /// <param name="bestScoreName">Name of the player with the best score</param>
    public void setTexts(string yourScore, string bestScore, string bestScoreName)
    {
        yourScoreText.text = yourScore;
        bestScoreText.text = bestScore;
        bestScoreNameText.text = '(' + bestScoreName + ')';
    }
}
