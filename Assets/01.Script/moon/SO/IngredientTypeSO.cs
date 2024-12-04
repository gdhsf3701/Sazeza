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
    private void OnValidate()
    {
        UpdateCost();
    }
    private void UpdateCost()
    {
        switch (Tire)
        {
            case 1:
                cost = 5000;
                break;
            case 2:
                cost = 4000;
                break;
            case 3:
                cost = 3000;
                break;
            default:
                cost = 0;
                break;
        }
    }
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