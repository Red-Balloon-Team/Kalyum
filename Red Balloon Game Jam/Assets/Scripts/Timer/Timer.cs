using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    [Header("Timer Setting")]
    public float currentTime;
    public bool countUp;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    private bool isEnabled = false;

    void Update()
    {
        if (isEnabled)
        {
            if (countUp)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }

            if (hasLimit && ((!countUp && currentTime <= timerLimit) || (countUp && currentTime >= timerLimit)))
            {
                currentTime = timerLimit;
                SetTimerText();
                timerText.color = Color.red;
                isEnabled = false;
            }

            SetTimerText();
        }
    }

    public void EnableTimer()
    {
        isEnabled = true;
    }

    private void SetTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        int milliseconds = Mathf.FloorToInt((currentTime * 1000) % 100);
        string timeString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timerText.text = timeString;
    }
}
