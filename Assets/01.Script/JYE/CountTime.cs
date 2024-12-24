using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CountTime : MonoBehaviour
{
    [SerializeField] private Timer timer;

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
        //다음씬으로
        GameManager.Instance.Stage4ScoreSet(int.Parse(DangoText.text),int.Parse(text.text)); //점수 계산
      
        SceneManager.LoadScene("Stage5");
       
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
