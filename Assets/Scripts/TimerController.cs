using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// class which controls the timer object
/// </summary>
public class TimerController : MonoBehaviour
{
    [SerializeField]
    private float timeStart = 20;
    private bool isActive = true;
    private TextMeshPro timerText;

    public float TimeStart { get => timeStart; set => timeStart = value; }
    public bool IsActive { get => isActive; set => isActive = value; }

    /// <summary>
    /// Start is called before the first frame update
    /// initiates the timer text and it's starting time
    /// </summary>
    void Start()
    {
       timerText = GetComponent<TextMeshPro>();
       timerText.text = TimeStart.ToString();
    }
    /// <summary>
    /// Update is called once per frame
    /// changes the time on a timer
    /// </summary>
    void Update()
    {
        if (IsActive)
        {
            TimeStart -= Time.deltaTime;
            if (Mathf.Round(TimeStart) >= 0)
                timerText.text = Mathf.Round(TimeStart).ToString();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns>current time on a timer</returns>
    public float GetCurrentTime()
    {
        return TimeStart;
    }

    
}
