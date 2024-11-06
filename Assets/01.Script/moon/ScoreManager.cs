using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public ScoreManager Instance { get; private set; }
    public int Score { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        Score = 0;
        DontDestroyOnLoad(gameObject);
    }
    public void ScoreUp(int scoreUp)
    {
        Score += scoreUp;
    }
    public void ScoreDown(int scoreDown)
    {
        Score += scoreDown;
    }
}
