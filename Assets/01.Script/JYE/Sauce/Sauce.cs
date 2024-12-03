using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sauce : MonoBehaviour
{
    public SauceScoreSO so;

    public int sauceScore;

    public TextMeshProUGUI sauceText;

    private void Awake()
    {
        sauceText = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
    }


    private void OnEnable()
    {
        Grant();
    }

    private void Grant()
    {
        sauceScore = so.type != SauceObjectType.Dango ? Random.Range(1, 16) : 5/*�⺻���� �־����� ��� ����*/; //��� �ƴ϶�� �ҽ� ���� �������� ���ϱ�

        sauceText.text = sauceScore.ToString(); //�ҽ� ���� ���̱�
    }
}
