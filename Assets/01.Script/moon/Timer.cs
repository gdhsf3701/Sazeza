using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    private bool isDone = false;
    public event Action OnTimerEnd;
    private void Update()
    {
        _time -= Time.deltaTime;
        if(_time <= 0 && !isDone)
        {
            isDone = true;
            OnTimerEnd?.Invoke();
        }
    }
}
