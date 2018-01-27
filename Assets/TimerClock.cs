using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalCountdown : MonoBehaviour
{

    private Text textClock;
    private float countdownTimerDuration;
    private float countdownTimerStartTime;

    void Start()
    {
        textClock = GetComponent<Text>();
        CountdownTimerReset(30);
    }

    void Update()
    {
        // default - timer finished
        string timerMessage = "countdown has finished";
        int timeLeft = (int)CountdownTimerSecondsRemaining();
        if (timeLeft > 0)
            timerMessage = "Countdown seconds remaining = " +
           LeadingZero(timeLeft);
        textClock.text = timerMessage;
    }

    private void CountdownTimerReset(float delayInSeconds)
    {
        countdownTimerDuration = delayInSeconds;
        countdownTimerStartTime = Time.time;
    }

    private float CountdownTimerSecondsRemaining()
    {
        float elapsedSeconds = Time.time -
       countdownTimerStartTime;
        float timeLeft = countdownTimerDuration -
       elapsedSeconds;
        return timeLeft;
    }

    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}