using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CountTime : MonoBehaviour
{
    [SerializeField] private Timer timer;

    [SerializeField] bool perfect;

    private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI DangoText;

    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        timer.OnTimerEnd += NextScene;
    }

    private void Update()
    {
        TimeText();
    }

    private void NextScene()
    {
        perfect = CheckText();
        //다음씬으로
        SceneManager.LoadScene("Stage5");
    }

    private bool CheckText() //완벽하게 점수 맞는지
    {
        return int.Parse(text.text) == int.Parse(DangoText.text);
    }

    private void TimeText() //시간 텍스트
    {
        timeText.text = ((int)timer.Timetime).ToString();
    }

    private void OnDisable()
    {
        timer.OnTimerEnd -= NextScene;
    }
}
