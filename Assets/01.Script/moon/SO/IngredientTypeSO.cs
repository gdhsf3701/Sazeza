using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/IngredientType")]
public class IngredientTypeSO : ScriptableObject
{
    public Sprite sprite;
    public int dirtyRate = 100;
    public string ToolTip;
}