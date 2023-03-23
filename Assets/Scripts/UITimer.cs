using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public float totalTime;
    private float timeRemaining;
    private Text timerText;

    void Start()
    {
        timeRemaining = totalTime;
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        //Unsure help to implement time onto the UI
        //This goes the same for points
        //Feedback would be appreciated
    }
}
