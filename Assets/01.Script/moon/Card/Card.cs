using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public IngredientTypeSO myCard;
    public SpriteRenderer myRenderer;
    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        myRenderer.sprite = myCard.sprite;
    }
}
