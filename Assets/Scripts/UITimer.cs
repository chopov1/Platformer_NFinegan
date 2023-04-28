using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UITimer : MonoBehaviour
{
    public float totalTime;
    private float timeRemaining;
    private TextMeshProUGUI timerText;

    void Start()
    {
        timeRemaining = totalTime;
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Time remaining update
        timeRemaining -= Time.deltaTime;

        // Minutes and seconds conversion
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        // Timer text update
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
