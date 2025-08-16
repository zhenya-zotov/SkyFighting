using UnityEngine;
using TMPro; // если используешь TextMeshPro

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f;   // стартовое время (в секундах)
    public bool isRunning = true;
    public TMP_Text timerText;          // сюда перетащи TimerText в инспекторе

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Время вышло!");
                timeRemaining = 0;
                isRunning = false;
                DisplayTime(timeRemaining);
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
