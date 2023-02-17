using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//adapted from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/#timer
public class LevelTimer : MonoBehaviour
{
    public float time;
    public TMP_Text m_TextComponent;
    private string timeAsText;
    private bool timerIsRunning = false;

    void Awake()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                if (time <= 10)
                {
                    m_TextComponent.color = Color.red;
                }
            }
            else
            {
                GameManager._Instance.setGameOver();
                time = 0;
                timerIsRunning = false;
            }
            DisplayTime(time);
            m_TextComponent.text = "Time left: " + timeAsText;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeAsText = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}