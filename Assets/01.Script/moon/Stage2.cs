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
        ToolkitManager.Instance.ChangeSceneName("2. 당고 재료 씻기");
    }
    private void Initialize()
    {
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
        mouseSprite.GetComponent<SpriteMask>().sprite = mouseSprite.sprite;
    } 
    private void NextScene()
    { 
        GameManager.Instance.DirtyRateToScore();
        SceneManager.LoadScene("Stage");
       
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
