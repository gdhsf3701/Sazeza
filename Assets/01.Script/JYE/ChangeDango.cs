using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDango : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite1;
    [SerializeField] private SpriteRenderer _sprite2;
    [SerializeField] private SpriteRenderer _sprite3;

    private void Awake()
    {
        SpriteChange();
    }
    public void SpriteChange()
    {
        _sprite1.sprite = GameManager.Instance.IngredientSO[GameManager.Instance.Ingredient[0]].sprite;
        _sprite2.sprite = GameManager.Instance.IngredientSO[GameManager.Instance.Ingredient[1]].sprite;
        _sprite3.sprite = GameManager.Instance.IngredientSO[GameManager.Instance.Ingredient[2]].sprite;
    }
}
