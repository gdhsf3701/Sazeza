using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    public IngredientTypeEnum MyIngredientType;
    private TextMeshPro text;
    private SpriteRenderer myRenderer;
    public void Initialize()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        text.text = $"Coin:{GameManager.Instance.IngredientSO[MyIngredientType].cost}";
        myRenderer.sprite = GameManager.Instance.IngredientSO[MyIngredientType].sprite;
    }
    public void Buy()
    {
        if(GameManager.Instance.Coin - GameManager.Instance.IngredientSO[MyIngredientType].cost >= 0)
        {
            GameManager.Instance.IngredientIsBuy[MyIngredientType] = true;
            GameManager.Instance.ScoreCange(-GameManager.Instance.IngredientSO[MyIngredientType].cost);
            gameObject.SetActive(false);
        }
    }
}
