using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public IngredientTypeEnum MyIngredientType;
    [SerializeField]private TextMeshProUGUI text;
    [SerializeField]private Image myRenderer;
    [SerializeField]private Button button;
    public void Initialize()
    {
        myRenderer = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponentInChildren<Button>();
        text.text = $"Coin:{GameManager.Instance.IngredientSO[MyIngredientType].cost}";
        myRenderer.sprite = GameManager.Instance.IngredientSO[MyIngredientType].sprite;
        button.onClick.AddListener(Buy);
    }
    public void Buy()
    {
        if(GameManager.Instance.Coin - GameManager.Instance.IngredientSO[MyIngredientType].cost >= 0)
        {
            GameManager.Instance.IngredientIsBuy[MyIngredientType] = true;
            GameManager.Instance.CoinCange(-GameManager.Instance.IngredientSO[MyIngredientType].cost);
            SoundManager.Instance.PlaySound(Sound.BuySuccess);
            gameObject.SetActive(false);
        }
        else
        {
            SoundManager.Instance.PlaySound(Sound.BuyFail);
        }
    }
}
