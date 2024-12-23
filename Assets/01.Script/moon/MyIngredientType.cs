using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyIngredientType : MonoBehaviour
{
    public IngredientTypeEnum myEnum;
    public SpriteRenderer mySprite;
    public bool isSouce = false;
    private void Awake()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }
}
