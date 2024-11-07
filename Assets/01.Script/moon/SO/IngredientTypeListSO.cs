using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/IngredientTypeList")]
public class IngredientTypeListSO : ScriptableObject
{
    public List<IngredientTypeSO> ingredientTypes;
}
