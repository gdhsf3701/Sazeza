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
        sauceScore = so.type != SauceObjectType.Dango ? Random.Range(1, 3) : 5/*�⺻���� �־����� ��� ����*/; //��� �ƴ϶�� �ҽ� ���� �������� ���ϱ�

        sauceText.text = sauceScore.ToString(); //�ҽ� ���� ���̱�
    }
}
