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
            Random.Range(1, 16): 5/*�⺻���� �־����� ��� ����*/; //��� �ƴ϶�� �ҽ� ���� �������� ���ϱ�

        so.sauceText.text = so.sauceScore.ToString(); //�ҽ� ���� ���̱�
    }
}
