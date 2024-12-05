using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDango : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        SpriteChange();
    }
    public void SpriteChange()
    {
        _sprite.sprite = GameManager.Instance.IngredientSO[GameManager.Instance.nowIngredientType].sprite;
    }
}
