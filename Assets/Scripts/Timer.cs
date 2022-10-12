using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField] private float timeDuration = 1f * 60f;

    private float timer;

    private bool finalGame = false;

    [SerializeField] private TextMeshProUGUI[] textMeshPros;


    private void Start()
    {
        timer = timeDuration;
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else
        {
            finalGame = true;
            Flash();
            GetTime();
        }

    }

    private void ResetTimer()
    {
        timer = timeDuration;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        textMeshPros[0].text = currentTime[0].ToString();
        textMeshPros[1].text = currentTime[1].ToString();
        textMeshPros[2].text = currentTime[2].ToString();
        textMeshPros[3].text = currentTime[3].ToString();
    }

    private void Flash()
    {
        if (timer != 0)
        {
            timer = 0;
            UpdateTimerDisplay(timer);
        }
    }

    public bool GetTime()
    {
        return finalGame;
    }
}
