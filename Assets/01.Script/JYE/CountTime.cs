using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CountTime : MonoBehaviour
{
    private Timer timer;

    private TextMeshProUGUI timeText;

    private void Awake()
    {
        timer = GetComponent<Timer>();
        timeText = GetComponent<TextMeshProUGUI>();
        timer.OnTimerEnd += NextScene;
    }

    private void Update()
    {
        TimeText();
    }

    private void NextScene()
    {
        //¥Ÿ¿Ωæ¿¿∏∑Œ
        SceneManager.LoadScene("Stage5");
    }

    private void TimeText()
    {
        timeText.text = ((int)timer.Timetime).ToString();
    }

    private void OnDisable()
    {
        timer.OnTimerEnd -= NextScene;
    }
}
