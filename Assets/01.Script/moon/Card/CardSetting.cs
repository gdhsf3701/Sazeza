using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Unity.Collections.LowLevel.Unsafe;
using Random = UnityEngine.Random;

public class CardSetting : MonoBehaviour
{
    [SerializeField]private GameObject prefab;
    [SerializeField]private GameObject nullCard;
    [SerializeField]private int xCardMany;
    [SerializeField]private int yCardMany;
    [SerializeField]private float distance = 0.1f;
    List<IngredientTypeEnum> cards = new List<IngredientTypeEnum>();
    private Vector2 startVetor;
    private Vector2 nowVecor;
    private void Start()
    {
        Initialize();
        for (int x = 0; x < xCardMany; x++)
        {
            for (int y = 0; y < yCardMany; y++)
            {
                if (cards.Count > 0)
                {
                    int rand = Random.Range(0, cards.Count);
                    GameObject temp = Instantiate(prefab, nowVecor, Quaternion.identity, transform);
                    if (temp.transform.TryGetComponent(out Card card) && cards.Count > 0)
                    {
                        card.myCard = cards[rand];
                        cards.RemoveAt(rand);
                    }
                }
                else
                {
                    Instantiate(nullCard, nowVecor, Quaternion.identity, transform);
                }
                nowVecor = new Vector2(nowVecor.x + distance + prefab.transform.GetChild(0).localScale.x, nowVecor.y);
            }
            nowVecor = new Vector2(startVetor.x, nowVecor.y - distance - prefab.transform.GetChild(0).localScale.y);
        }
    }
    private void Initialize()
    {
        startVetor = transform.position;
        startVetor = new Vector2(startVetor.x + prefab.transform.localScale.x / 2, startVetor.y - prefab.transform.localScale.y / 2);
        nowVecor = startVetor;
        InitializeCards();
    }
    private void InitializeCards()
    {
        foreach(IngredientTypeEnum ingredientType in Enum.GetValues(typeof(IngredientTypeEnum)))
        {
            if (GameManager.Instance.IngredientIsBuy[ingredientType])
            {
                cards.Add(ingredientType);
            }
        }

    }
}
