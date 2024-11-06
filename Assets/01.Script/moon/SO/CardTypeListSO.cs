using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/CardTypeList")]
public class CardTypeListSO : ScriptableObject
{
    public Sprite backgroundSprite;
    public List<CardTypeSO> cardTypeList;
}
