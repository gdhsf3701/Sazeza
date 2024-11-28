using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum IngredientTypeEnum
{
    WhiteTteok,
    PinkTteok,
    LightGreenTteok,
    CoconutJelly,
    ShineMuscat,
    SiruTteok,
    PoppedRice,
    Pineapple,
    
    TalkingFireExtinguisher,
    Metamorph,
    Purin,
    Shoes,
    ArahashiTabi,
    MobilePhone,
    Mouse,
    Photoshop,
    Unity,
    Laptop,
    LightBulb,
    Globe,
    GitHub,
    Glasses,
    Pikmin,
    Paimon
}
public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }
    [field:SerializeField]public int Coin { get; private set; }
    public List<IngredientTypeEnum> Ingredient { get; private set; }
    public event Action<IngredientTypeEnum> OnIngredientAdd;
    public Dictionary<IngredientTypeEnum, IngredientTypeSO> IngredientSO { get; private set; }
    public Dictionary<IngredientTypeEnum, int> IngredientScore { get; private set; }
    public Dictionary<IngredientTypeEnum, int> IngredientDirtyRate { get; private set; }
    public Dictionary<IngredientTypeEnum, bool> IngredientIsBuy { get; private set; }
    public IngredientTypeEnum nowIngredientType { get; set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Initialize();
    }
    public void AddIngredient(IngredientTypeEnum add)
    {
        Ingredient.Add(add);
        OnIngredientAdd?.Invoke(add);
    }
    public void IngredientDirtyRateMinus(IngredientTypeEnum ingredientType , int rate)
    {
        IngredientDirtyRate[ingredientType] -= rate;
        if(IngredientDirtyRate[ingredientType] <= 0)
        {
            IngredientDirtyRate[ingredientType] = 0;
        }
    }
    public void IngredientDirtyRatePlus(IngredientTypeEnum ingredientType , int rate)
    {
        IngredientDirtyRate[ingredientType] += rate;
        if (IngredientDirtyRate[ingredientType] <= 100)
        {
            IngredientDirtyRate[ingredientType] = 100;
        }
    }
    public IngredientTypeSO GetIngredint(int i)
    {
        return IngredientSO[Ingredient[i]];
    }
    private void Initialize()
    {
        Coin = 0;
        Ingredient = new List<IngredientTypeEnum>();
        IngredientSO = new Dictionary<IngredientTypeEnum, IngredientTypeSO>();
        IngredientScore = new Dictionary<IngredientTypeEnum, int>();
        IngredientDirtyRate = new Dictionary<IngredientTypeEnum, int>();
        IngredientIsBuy = new Dictionary<IngredientTypeEnum, bool>();
        DictionaryInitialize();
    }
    private void DictionaryInitialize()
    {
        foreach (IngredientTypeEnum ingredientType in Enum.GetValues(typeof(IngredientTypeEnum)))
        {
            string enumName = ingredientType.ToString();
            IngredientTypeSO ingredientTypeSO = Resources.Load<IngredientTypeSO>(enumName);

            if (ingredientTypeSO != null)
            {
                IngredientSO.Add(ingredientType, ingredientTypeSO);
                IsBuyInitialize(ingredientType);
            }
            else
            {
                Debug.LogWarning($"ScriptableObject for {enumName} not found in Resources.");
            }
        }
    }
    private void IsBuyInitialize(IngredientTypeEnum ingredientType)
    {
        if (IngredientSO[ingredientType].Tire >= 4)
        {
            IngredientIsBuy.Add(ingredientType, true);
        }
        else
        {
            IngredientIsBuy.Add(ingredientType, false);
        }
    }
    public void ScoreCange(int scoreCangeRange)
    {
        Coin += scoreCangeRange;
    }
    public void ResetIngredient()
    {
        Ingredient = new List<IngredientTypeEnum>();
        IngredientScore = new Dictionary<IngredientTypeEnum, int>();
        IngredientDirtyRate = new Dictionary<IngredientTypeEnum, int>();
    }

}
