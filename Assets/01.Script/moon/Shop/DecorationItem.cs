using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecorationItem : MonoBehaviour
{
    [SerializeField] Sprite mySprite;
    [SerializeField] int myRenSprite;
    [SerializeField] string myType;
    private Image myRenderer;
    private Button button;
    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        myRenderer = GetComponentInChildren<Image>();
        button = GetComponentInChildren<Button>();
        myRenderer.sprite = mySprite;
        button.onClick.AddListener(Change);
    }
    public void Change()
    {
        HomeManager.Instance.SetAnimator(myType,myRenSprite);
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
    }
}
