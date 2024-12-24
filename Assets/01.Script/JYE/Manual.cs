using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    private int page; //������ �� 0: �ݱ�, 1: ù������, 2, 3, 4:����������

    public GameObject manual;//����

    public TextMeshProUGUI bTxt; //����
    public TextMeshProUGUI sTxt; //��ȣ (�ΰ� ����)
    public GameObject textAndImage;
    private TextMeshProUGUI tAITxt;
    public Image[] images;
    public GameObject ex; //3����

    private void Awake()
    {
        tAITxt = textAndImage.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        CloseM();
    }

    private void Update()
    {
        Page();
    }

    private void Page()
    {
        switch (page)
        {
            case 0:
                CloseM();
                break;
            case 1:
                manual.SetActive(true);
                bTxt.text = "ó�� ������ �� �մ��� ���� ���� ���� �����Ͽ� ������ ���ϴ�.";
                sTxt.text = "�Ϸ翡 1m���� �ڶ�⵵ ��.";
                tAITxt.text = "-> �볪��";
                break;
            case 2:
                bTxt.text = "�� ������ ���� Ŭ���Ͽ� ��Ḧ ������ �Ľ��ϴ�.";
                sTxt.text = "(�ð� ������ ������ ���� �� ���� Ŭ�� �� �ٽ� ������ ���ϴ�.)";
                tAITxt.text = "-> ��";
                break;
            case 3:
                bTxt.text = "�׸��� �ҽ��� ���� ������ ��ġ�� �ɾ� ��� ����� �˴ϴ�.";
                sTxt.text = "(������ ��� ������ ��� ��Ḧ ���� �ɾƾ� ��.)";
                tAITxt.text = "-> �볪��";
                break;
            case 4:
                SceneManager.LoadScene("MySweetHome");
                break;
        }
        Images();
    }

    private void Images()
    {
        images[0].gameObject.SetActive(page == 1);
        images[1].gameObject.SetActive(page == 2);
        textAndImage.SetActive(page <= 2);
        ex.SetActive(page == 3);
    }

    private void CloseM()
    {
        manual.SetActive(false);
    }

    public void StB()
    {
        page = 1;
    }

    public void QuitB()
    {
        Application.Quit();
    }

    public void BeforeB()
    {
        page--;
    }

    public void NextB()
    {
        page++;
    }

    public void SkipB()
    {
        page = 4;
    }
}
