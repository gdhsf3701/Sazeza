using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Manual : MonoBehaviour
{
    private int page; //페이지 수 0: 닫기, 1: 첫페이지, 2, 3, 4:다음씬으로

    public GameObject manual;//설명서

    public TextMeshProUGUI bTxt; //설명
    public TextMeshProUGUI sTxt; //괄호 (부과 설명)
    public GameObject textAndImage;
    private TextMeshProUGUI tAITxt;
    public Image[] images;
    public GameObject ex; //3예시

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
                bTxt.text = "처음 시작할 때 손님이 말한 것을 보고 유추하여 재료들을 고릅니다.";
                sTxt.text = "하루에 1m정도 자라기도 해.";
                tAITxt.text = "-> 대나무";
                break;
            case 2:
                bTxt.text = "그 다음은 물을 클릭하여 재료를 깨끗이 씻습니다.";
                sTxt.text = "(시간 제한이 있으며 엉뚱 한 곳을 클릭 시 다시 더러워 집니다.)";
                tAITxt.text = "-> 물";
                break;
            case 3:
                bTxt.text = "그리고 소스가 묻힌 당고들을 꼬치에 꽃아 당고를 만들면 됩니다.";
                sTxt.text = "(순서는 상관 없지만 당고 재료를 전부 꽃아야 함.)";
                tAITxt.text = "-> 대나무";
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
