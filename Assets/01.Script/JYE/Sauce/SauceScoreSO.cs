using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(menuName = "SO/JYE/SauceScore")]
public class SauceScoreSO : ScriptableObject
{
    public SauceObjectType type; //����
}

public enum SauceObjectType
{
    Dango/*�÷��̾�*/, SauceBall/*�ҽ���*/, Spoon/*������*/
}
