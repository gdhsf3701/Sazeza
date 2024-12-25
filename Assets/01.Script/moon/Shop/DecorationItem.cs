using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DecorationItem : MonoBehaviour
{
    private Image myRenderer;
    [SerializeField] Sprite mySprite;
    [SerializeField] int myRenSprite;
    private Button button;
    public void Initialize()
    {
        myRenderer = GetComponentInChildren<Image>();
        button = GetComponentInChildren<Button>();
        myRenderer.sprite = mySprite;
        button.onClick.AddListener(Change);
    }
    public void Change()
    {
        SoundManager.Instance.PlaySound(Sound.ButtonClick);
    }
}
