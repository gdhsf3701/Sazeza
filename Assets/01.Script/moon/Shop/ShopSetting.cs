using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShopSetting : MonoBehaviour
{
    //[SerializeField] private int xCardMany;
    //[SerializeField] private int yCardMany;
    //[SerializeField] private float distance = 0.1f;
    [SerializeField] private GameObject prefab;
    //[SerializeField] private GameObject nullItem;
    [SerializeField] Transform Parent;
    List<IngredientTypeEnum> BuyThing = new List<IngredientTypeEnum>();
    //private Vector2 startVetor;
    //private Vector2 nowVecor;
    private void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        //transform.position = new Vector3(-(prefab.transform.localScale.x * 2 + distance * 2), prefab.transform.localScale.y * 2 + distance * 2, 0);
        //startVetor = transform.position;
        //startVetor = new Vector2(startVetor.x + prefab.transform.localScale.x / 2, startVetor.y - prefab.transform.localScale.y / 2);
        //nowVecor = startVetor;
        InitializeItems();
    }
    private void InitializeItems()
    {
        foreach (IngredientTypeEnum ingredientType in Enum.GetValues(typeof(IngredientTypeEnum)))
        {
            if (!GameManager.Instance.IngredientIsBuy[ingredientType])
            {
                BuyThing.Add(ingredientType);
            }
        }

    }
    private void Start()
    {
        //for (int x = 0; x < xCardMany; x++)
        //{
        //    for (int y = 0; y < yCardMany; y++)
        //    {
        //        if (BuyThing.Count > 0)
        //        {
        //            int rand = Random.Range(0, BuyThing.Count);
        //            GameObject temp = Instantiate(prefab, nowVecor, Quaternion.identity, transform);
        //            if (temp.transform.GetChild(0).TryGetComponent(out Item item) && BuyThing.Count > 0)
        //            {
        //                item.MyIngredientType = BuyThing[rand];
        //                item.Initialize();
        //                BuyThing.RemoveAt(rand);
        //            }
        //        }
        //        else
        //        {
        //            Instantiate(nullItem, nowVecor, Quaternion.identity, transform);
        //        }
        //        nowVecor = new Vector2(nowVecor.x + distance + prefab.transform.localScale.x, nowVecor.y);
        //    }
        //    nowVecor = new Vector2(startVetor.x, nowVecor.y - distance - prefab.transform.localScale.y);
        //}
        for(int i = 0; i < BuyThing.Count; i++)
        {
            int rand = Random.Range(0, BuyThing.Count);
            GameObject temp = Instantiate(prefab , Parent);
            if (temp.transform.GetChild(0).TryGetComponent(out Item item) && BuyThing.Count > 0)
            {
                item.MyIngredientType = BuyThing[rand];
                item.Initialize();
                BuyThing.RemoveAt(rand);
            }
        }
    }
    public void SetCard(int i)
    {
        
    }
}
