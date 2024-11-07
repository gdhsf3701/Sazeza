using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/CardType")]
public class CardTypeSO : ScriptableObject
{
    [field:SerializeField]public Sprite CardSprite { get; private set; }
    [HideInInspector]public bool IsStone = false;
    [field: SerializeField]public int Score { get; private set; }
    [field: SerializeField] public int CleanRate { get; private set; } = 0;
    [field: SerializeField] public bool IsStrange { get; private set; }
}
