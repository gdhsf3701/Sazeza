using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Stage2 : MonoBehaviour
{
    private List<IngredientTypeEnum> ingredientTypes = new List<IngredientTypeEnum>();
    [SerializeField] float _timer = 180;
    private void Start()
    {
        Initialize();
        ToolkitManager.Instance.ChangeSceneName("��");
    }
    private void Initialize()
    {
        foreach(var type in GameManager.Instance.Ingredient)
        {
            ingredientTypes.Add(type);
        }
        int rand = Random.Range(0, GameManager.Instance.Ingredient.Count);
        GameManager.Instance.nowIngredientType = ingredientTypes[rand];
        ingredientTypes.RemoveAt(rand);
    }
    public void NewIngredientType()
    {
        if(ingredientTypes.Count <= 0)
        {
            NextScene();
            return;
        }
        int rand = Random.Range(0, ingredientTypes.Count);
        GameManager.Instance.nowIngredientType = ingredientTypes[rand];
        ingredientTypes.RemoveAt(rand);
    }
    private void NextScene()
    {
        SceneManager.LoadScene("Stage3");
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            NextScene();
        }
    }
}
