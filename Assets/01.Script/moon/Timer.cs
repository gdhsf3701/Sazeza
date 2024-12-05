using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    public float Timetime { get; set; }
    private bool isDone = false;
    public event Action OnTimerEnd;

    private void Awake()
    {
        ToolkitManager.Instance.ChangeSceneName("4. 당고시럽 바르기");
        Timetime = _time;
    }

    private void Update()
    {
        Timetime -= Time.deltaTime;
        if(Timetime <= 0 && !isDone)
        {
            isDone = true;
            OnTimerEnd?.Invoke();
        }
    }
}
