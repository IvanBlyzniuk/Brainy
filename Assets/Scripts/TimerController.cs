using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private float timeStart = 20;
    private bool isActive = true;
    private TextMeshPro timerText;

    public float TimeStart { get => timeStart; set => timeStart = value; }
    public bool IsActive { get => isActive; set => isActive = value; }

    // Start is called before the first frame update
    void Start()
    {
       timerText = GetComponent<TextMeshPro>();
       timerText.text = TimeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
        {
            TimeStart -= Time.deltaTime;
            if (Mathf.Round(TimeStart) >= 0)
                timerText.text = Mathf.Round(TimeStart).ToString();
        }
    }
    public float GetCurrentTime()
    {
        return TimeStart;
    }

    
}
