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
    [SerializeField] SpriteRenderer mouseSprite;
    private void Start()
    {
        Initialize();
        ToolkitManager.Instance.ChangeSceneName("2. ��� ��� �ı�");
    }
    private void Initialize()
    {
        ToolkitManager.Instance.Paid();
        foreach(var type in GameManager.Instance.Ingredient)
        {
            ingredientTypes.Add(type);
        }
        int rand = Random.Range(0, GameManager.Instance.Ingredient.Count);
        GameManager.Instance.NowIngredientType = ingredientTypes[rand];
        ingredientTypes.RemoveAt(rand);
        MouseSpriteChange();
    }
    public void NewIngredientType()
    {
        if(ingredientTypes.Count <= 0)
        {
            NextScene();
            return;
        }
        int rand = Random.Range(0, ingredientTypes.Count);
        GameManager.Instance.NowIngredientType = ingredientTypes[rand];
        ingredientTypes.RemoveAt(rand);
        MouseSpriteChange();
    }
    public void MouseSpriteChange()
    {
        mouseSprite.sprite = GameManager.Instance.IngredientSO[GameManager.Instance.NowIngredientType].sprite;
    } 
    private void NextScene()
    {
        SceneManager.LoadScene("Stage3");
         ToolkitManager.Instance.Padii();
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
