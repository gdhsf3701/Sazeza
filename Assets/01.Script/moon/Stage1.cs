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
    private float timer = 10f;
    private bool isFirst = true;
    private int nowIngredientCount => GameManager.Instance.Ingredient.Count;
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            Ingredient.Add(IngredentSetting());
        }
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
            GameManager.Instance.IngredientScore.Add(add,500 + GameManager.Instance.IngredientSO[add].PlusScore());
        }
        else
        {
            GameManager.Instance.IngredientScore.Add(add, 500 - (GameManager.Instance.IngredientSO[add].PlusScore()/2));
        }
        GameManager.Instance.IngredientDirtyRate.Add(add, 100);
        if (nowIngredientCount >= 3)
        {
            SceneManager.LoadScene("Stage2");
        }
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if (isFirst)
            {
                timer = 10f;
                IsFirstSetting();
            }
        } 
    }
    private IngredientTypeEnum IngredentSetting()
    {
        IngredientTypeEnum[] allIngredients = (IngredientTypeEnum[])Enum.GetValues(typeof(IngredientTypeEnum));
        List<IngredientTypeEnum> validIngredients = new List<IngredientTypeEnum>();

        foreach (var ingredient in allIngredients)
        {
            if (!Ingredient.Contains(ingredient))
            {
                validIngredients.Add(ingredient);
            }
        }

        if (validIngredients.Count == 0)
        {
            throw new InvalidOperationException("조건을 만족하는 재료가 없습니다.");
        }

        return validIngredients[Random.Range(0, validIngredients.Count)];
    }
    private void IsFirstSetting()
    {
        isFirst = false;
        OnCanSelect?.Invoke();
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
