using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyIngredientType : MonoBehaviour
{
    public IngredientTypeEnum myEnum;
    public SpriteRenderer mySprite;
    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }
}
