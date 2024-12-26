using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetString : MonoBehaviour
{
    [SerializeField] private float _timer = 10f;
    private string[] hi = new string[] { 
        "�� �丮��� ����� �� �丮�� �ϴ� ���� �� ���� ����.",
        "���� ȯ������ ����� ��� �ҰԿ�.",
        "�̷�, ������ �þƵ� ��ħ�� ���°�.",
        "õ���� ��õ�� �����, ���� ���Ǵ°�.",
        "�ҹ��� ���ϸ� �� ����� �����������...",
        "�� ����� ���ִٸ� ������ �Ű��� �����̾�.",
        "������ �� ������ �ִٴ� ���� ���β����� ���� �ʿ���ٴ� �ű���.",
        "�� ��� �����ϸ�.",
        "��� ��ſ� �� ���� ��.",
        "�Ͽ�.",
        "���� �� �ٱ�, �Ķ� �� �ٱ�?",
        "�� ���� ���� ���� ���־�.",
        "�ʹ� ���� ���ͼ� �谡 ���� �ǰھ��.",
        "�� ���� �� ���� �� ���ξ�.",
        "���� �� ��� ���� �� ������ ��ư��� �Ǿ����.",
        "�� ���� ��, ���, �� �����, ���� �λ�, ���� ��,",
        "���� 70�￡ ��� ���� �ִٸ� ���� ���� �ϳ� �� �� ...................",
        "��� = ��",
        "�������� ����� ���� ������ öȸ�Ѵ� ���� ����� �������� �� ���� �Ǿ� ����� ���� ������ ���� ���� �������� �����ϰڴ�.",
        "������ ���� ����� �ľ���",
        "�ϴ����� ȫ�ذ� ������ ���� ����� �İ��"
    };
    float nowTime = 0;
    private void Start()
    {
        nowTime = _timer;
    }
    private void Update()
    {
        nowTime -= Time.deltaTime;
        if(nowTime < 0)
        {
            nowTime = _timer;

        }
    }
    private void SetString()
    {
        int rand = Random.Range(0, hi.Length);
        ToolkitManager.Instance.SetScore(hi[rand]);
    }
}