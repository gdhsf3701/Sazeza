using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sauce : MonoBehaviour
{
    public SauceScoreSO so;

    private void Awake()
    {
        so.sauceText = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        Grant();
    }

    private void Grant()
    {
        so.sauceScore =
            so.type != SauceObjectType.Dango?
            Random.Range(1, 16): 5/*기본으로 주어지는 당고 점수*/; //당고가 아니라면 소스 점수 랜덤으로 정하기

        so.sauceText.text = so.sauceScore.ToString(); //소스 점수 보이기
    }
}
