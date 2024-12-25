using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class ToolkitManager : MonoBehaviour
{
   static public ToolkitManager Instance { get; private set; }
    private Label ChangName;
    private Label scroe;
    private Label toolTip1;
    private Label toolTip2;
    private Label toolTip3;
    private Label toolTip1P;
    private Label toolTip2P;
    private Label toolTip3P;
    private VisualElement tooltipPaper;
    private VisualElement chang;
    private VisualElement pade;
    private Button gotoShop;
    [SerializeField] GameObject UI;
 

    private void Awake()
    {

        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void opem()
    {
        StartCoroutine(Opne());
    }
    IEnumerator Opne()
    {
        yield return new WaitForSeconds(4f);
        gotoShop.style.display = DisplayStyle.Flex;
    }

    
    private void Start()
    {
        var root = GetComponentInChildren <UIDocument>().rootVisualElement;
        ChangName = root.Q<Label>("ScenName");
        scroe = root.Q<Label>("Score");
      chang = root.Q<VisualElement>("Chang");
        pade = root.Q<VisualElement>("Pade");
        toolTip1 = root.Q<Label>("Tooltip1");
        toolTip2= root.Q<Label>("Tooltip2");
        toolTip3 = root.Q<Label>("Tooltip3");
        toolTip1P = root.Q<Label>("Tooltip1p");
        toolTip2P = root.Q<Label>("Tooltip2p");
        toolTip3P = root.Q<Label>("Tooltip3p");
        tooltipPaper = root.Q<VisualElement>("TooltipPaper");
        gotoShop = root.Q<Button>("BackStart");
        


        gotoShop.RegisterCallback<ClickEvent>(BackStage1);
        
        gotoShop.style.display = DisplayStyle.None;
        UI.SetActive(false);

       
       
    }
    public void timer2(int a)
    {
        StartCoroutine(Paper(a));
    }
    public IEnumerator Paper(int a )
    {
        tooltipPaper.style.display = DisplayStyle.Flex;
        
        yield return new WaitForSeconds(a);

        tooltipPaper.style.display = DisplayStyle.None;
        tooltipPaper.pickingMode = PickingMode.Ignore;
        chang.pickingMode = PickingMode.Ignore;
      //  pade.pickingMode = PickingMode.Ignore;

    }

    

    public void ChangeSceneName(string name)
    {
        ChangName.text = "당고 만들기 게임.exe : " + name;
    }

    public void SetScore(string str)
    {
        scroe.text = str;
    }

    public void SetResult()
    {
        GameManager.Instance.VIPCheck();
        toolTip1P.text = "받은 점수 : "+GameManager.Instance.Score.ToString();
        toolTip2P.text = "받은 코인 : " +GameManager.Instance.ScoreToCoin().ToString();
        toolTip3P.text = "최종 보유 코인 : "+ GameManager.Instance.Coin.ToString();
    }

    public void GoStage1()
    {
        UI.SetActive(true);
        SceneManager.LoadScene("Stage1");
        ChangeSceneName("1. 당고 재료 선택하기");
        StartCoroutine(Paper(3));

    }
    public void BackStage1(ClickEvent evt)
    {
           
        SceneManager.LoadScene("Stage1");
        gotoShop.style.display = DisplayStyle.None;

    }

    public void GoToMyHome()
    {
        SceneManager.LoadScene("MySweetHome");
        UI.SetActive(false);
    }
    
    
    public void SetTooltip(string a , int p)
    {
        switch (p)
        {
            case 0:
                toolTip1.text = a;
                toolTip1P.text = a;
                break;
            case 1:
                toolTip2.text = a;
                toolTip2P.text = a;
                break;
            case 2: 
                toolTip3.text = a;
                toolTip3P.text = a;
                break;
            default:
                break;
        }
           
       
        
        
        
    }


}
