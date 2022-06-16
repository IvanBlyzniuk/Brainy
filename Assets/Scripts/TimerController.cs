using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public float timeStart = 20;
    public bool isActive = true;
    private TextMeshPro timerText;
    // Start is called before the first frame update
    void Start()
    {
       timerText = GetComponent<TextMeshPro>();
       timerText.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            timeStart -= Time.deltaTime;
            if (Mathf.Round(timeStart) >= 0)
                timerText.text = Mathf.Round(timeStart).ToString();
        }
    }
    public float GetCurrentTime()
    {
        return timeStart;
    }
}
