using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "SO/JYE/SauceScore")]
public class SauceScoreSO : ScriptableObject
{
    public TextMeshProUGUI sauceText; //텍스트
    public SauceObjectType type; //종류
}

public enum SauceObjectType
{
    Dango/*플레이어*/, SauceBall/*소스공*/, Spoon/*숟가락*/
}
