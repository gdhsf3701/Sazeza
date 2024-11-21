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
    public int Score { get; private set; }
    public List<IngredientTypeEnum> Ingredient { get; private set; }
    public event Action<IngredientTypeEnum> OnIngredientAdd;
    public Dictionary<IngredientTypeEnum, IngredientTypeSO> IngredientSO { get; private set; }  

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
    private void Initialize()
    {
        Score = 0;
        Ingredient = new List<IngredientTypeEnum>();
        IngredientSO = new Dictionary<IngredientTypeEnum, IngredientTypeSO>();
        DictionaryInitialize();
    }
    private void DictionaryInitialize()
    {
        foreach (IngredientTypeEnum ingredientType in Enum.GetValues(typeof(IngredientTypeEnum)))
        {
            string enumName = ingredientType.ToString();
            string[] guids = AssetDatabase.FindAssets($"t:IngredientTypeSO {enumName}");
            if (guids.Length > 0)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                IngredientTypeSO ingredientTypeSO = AssetDatabase.LoadAssetAtPath<IngredientTypeSO>(path);
                IngredientSO.Add(ingredientType, ingredientTypeSO);
                Debug.Log($"Loaded {ingredientTypeSO.name} for {ingredientType}");
            }
            else
            {
                Debug.LogWarning($"ScriptableObject for {enumName} not found.");
            }
        }
    }
    public void ScoreCange(int scoreCangeRange)
    {
        Score += scoreCangeRange;
    }
    
}
