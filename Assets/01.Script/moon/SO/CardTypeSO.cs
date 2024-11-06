using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/CardType")]
public class CardTypeSO : ScriptableObject
{
    [field:SerializeField]public Sprite cardSprite { get; private set; }
    [HideInInspector]public bool isStone = false;
    [field: SerializeField] public bool isStrange { get; private set; }
}
