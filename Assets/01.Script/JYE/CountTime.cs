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
        //����������
        SceneManager.LoadScene("Stage5");
    }

    private bool CheckText() //�Ϻ��ϰ� ���� �´���
    {
        return int.Parse(text.text) == int.Parse(DangoText.text);
    }

    private void TimeText() //�ð� �ؽ�Ʈ
    {
        timeText.text = ((int)timer.Timetime).ToString();
    }

    private void OnDisable()
    {
        timer.OnTimerEnd -= NextScene;
    }
}
