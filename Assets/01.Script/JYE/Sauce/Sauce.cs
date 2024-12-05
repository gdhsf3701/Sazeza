using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sauce : MonoBehaviour
{
    public SauceScoreSO so;

    public int sauceScore;

    public TextMeshPro sauceText;

    private void Awake()
    {
        sauceText = GetComponentInChildren<TextMeshPro>();
    }


    private void OnEnable()
    {
        Grant();
    }

    private void Grant()
    {
        sauceScore = so.type != SauceObjectType.Dango ? Random.Range(1, 3) : 5/*기본으로 주어지는 당고 점수*/; //당고가 아니라면 소스 점수 랜덤으로 정하기

        sauceText.text = sauceScore.ToString(); //소스 점수 보이기
    }
}
