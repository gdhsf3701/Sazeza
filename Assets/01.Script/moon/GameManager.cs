using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum IngredientTypeEnum
{
    WhiteTteok,
    PinkTteok,
    LightGreenTteok,
    CoconutJelly,
    ShineMuscat,
    SiruTteok,
    PoppedRice,
    Pineapple,
    
    TalkingFireExtinguisher,
    Metamorph,
    Purin,
    Shoes,
    ArahashiTabi,
    MobilePhone,
    Mouse,
    Photoshop,
    Unity,
    Laptop,
    LightBulb,
    Globe,
    GitHub,
    Glasses,
    Pikmin,
    Paimon
}
public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }
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
        int rand = Random.Range(0,Enum.GetValues(typeof(IngredientTypeEnum)).Length);
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
