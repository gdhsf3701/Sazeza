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
    private float timer = 3f;
    private bool isFirst = true;
    private int nowIngredientCount => GameManager.Instance.Ingredient.Count;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Ingredient.Add(IngredentSetting());
        }
        ToolkitManager.Instance.ChangeSceneName("1. 당고 재료 선택하기");
        ToolkitManager.Instance.Paid();
        ToolTipSetting();
        GameManager.Instance.OnIngredientAdd += ScoreUP;
        SoundManager.Instance.PlaySound(Sound.BellRing);
        SoundManager.Instance.PlaySound(Sound.Paper);
    }
    private void ScoreUP(IngredientTypeEnum add)
    {
        if (Ingredient.Contains(add))
        {
            GameManager.Instance.PlusScore(500 + GameManager.Instance.IngredientSO[add].PlusScore());
        }
        else
        {
            GameManager.Instance.PlusScore(500 - (GameManager.Instance.IngredientSO[add].PlusScore()/2));
        }
        GameManager.Instance.IngredientDirtyRate.Add(add, 0);
        if (nowIngredientCount >= 3)
        {
            ToolkitManager.Instance.Padii();
            SceneManager.LoadScene("Stage");
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
            if (!Ingredient.Contains(ingredient)&& GameManager.Instance.IngredientIsBuy[ingredient])
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
            ToolkitManager.Instance.SetTooltip(GameManager.Instance.IngredientSO[item].ToolTip, i);
            i++;
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.OnIngredientAdd -= ScoreUP;
    }
}
