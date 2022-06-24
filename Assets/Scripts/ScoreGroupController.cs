using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreGroupController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI yourScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreNameText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTexts(string yourScore, string bestScore, string bestScoreName)
    {
        yourScoreText.text = yourScore;
        bestScoreText.text = bestScore;
        bestScoreNameText.text = '(' + bestScoreName + ')';
    }
}
