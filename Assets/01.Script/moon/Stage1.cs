using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Stage1 : MonoBehaviour
{
    public List<IngredientTypeEnum> Ingredient;
    public event Action OnCanSelect;
    private float Timer;
    private bool isFirst;
    private int nowIngredientCount => GameManager.Instance.Ingredient.Count;
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            Ingredient.Add(IngredentSetting());
        }
        Timer = 10f;
    }
    private void Start()
    {
        ToolTipSetting();
        GameManager.Instance.OnIngredientAdd += ScoreUP;
    }
    private void ScoreUP(IngredientTypeEnum add)
    {
        if (Ingredient.Contains(add))
        {
            GameManager.Instance.ScoreCange(500);
        }
        if (nowIngredientCount >= 3)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
    private void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            if (isFirst)
            {
                IsFirstSetting();
            }
            else
            {
                SceneManager.LoadScene("Stage2");
            }
        } 
    }
    private IngredientTypeEnum IngredentSetting()
    {
        IngredientTypeEnum randomIngredient = (IngredientTypeEnum)Random.Range(0, Enum.GetValues(typeof(IngredientTypeEnum)).Length);
        if (Ingredient.Contains(randomIngredient))
        {
            return randomIngredient;
        }
        else
        {
            return IngredentSetting();
        }
    }
    private void IsFirstSetting()
    {
        isFirst = false;
        OnCanSelect?.Invoke();
        Timer = 10f;
        UIManager.Instance.gameObjects[0].SetActive(false);
    }
    private void ToolTipSetting()
    {
        int i = 0;
        foreach(var item in Ingredient)
        {
            UIManager.Instance.texts[i].text = GameManager.Instance.IngredientSO[item].ToolTip;
            i++;
        }
    }
}
