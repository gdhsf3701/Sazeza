using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/IngredientType")]
public class IngredientTypeSO : ScriptableObject
{
    [Header("IngredientSetting")]
    public Sprite sprite;
    public int dirtyRate = 100;
    public string ToolTip;
    [Header("IngredientCost")]
    public int Tire = 1;
    public int cost = 0;
    public bool isBuyed = true;

    public int PlusScore()
    {
        switch(Tire)
        {
            case 1:
                return 200;
            case 2:
                return 150;
            case 3:
                return 100;
            default: 
                return 0;

        }
    }
}