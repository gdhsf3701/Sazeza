using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public IngredientTypeEnum myCard;
    public Image myRenderer;
    public Button myButton;
    private void Start()
    {
        myRenderer = GetComponentInChildren<Image>();
        myButton = GetComponentInChildren<Button>();
        myRenderer.sprite = GameManager.Instance.IngredientSO[myCard].sprite;
        myButton.onClick.AddListener(OnButtonCliced);
    }
    private void OnButtonCliced()
    {
        myButton.onClick.RemoveAllListeners();
        GameManager.Instance.AddIngredient(myCard);
        myRenderer.enabled = false;
        myButton.enabled = false;
    }
}
