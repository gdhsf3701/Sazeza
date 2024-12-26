using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ToolkitManager : MonoSingleton<ToolkitManager>
{
  
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

   public static int pip = 0;



    
    public void opem()
    {
        StartCoroutine(Opne());
    }
    IEnumerator Opne()
    {
        yield return new WaitForSeconds(4f);
       
    }

    public void pip0()
    {
        pip = 0;
    }
    public void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ChangName = root.Q<Label>("ScenName");
        scroe = root.Q<Label>("Score");
        chang = root.Q<VisualElement>("Chang");
        toolTip1 = root.Q<Label>("Tooltip1");
        toolTip2 = root.Q<Label>("Tooltip2");
        toolTip3 = root.Q<Label>("Tooltip3");
        toolTip1P = root.Q<Label>("Tooltip1p");
        toolTip2P = root.Q<Label>("Tooltip2p");
        toolTip3P = root.Q<Label>("Tooltip3p");
        tooltipPaper = root.Q<VisualElement>("TooltipPaper");
        if(pip == 0)
        {
            ChangeSceneName("1. ��� ��� �����ϱ�");
            StartCoroutine(Paper(3));
            pip++;
        }

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
        ChangName.text = "��� ����� ����.exe : " + name;
    }

    public void SetScore(string str)
    {
        scroe.text = str;
    }

    public void SetResult()
    {
        GameManager.Instance.VIPCheck();
        toolTip1P.text = "���� ���� : "+GameManager.Instance.Score.ToString();
        toolTip2P.text = "���� ���� : " +GameManager.Instance.ScoreToCoin().ToString();
        toolTip3P.text = "���� ���� ���� : "+ GameManager.Instance.Coin.ToString();
    }

    public void GoStage1()
    {
        SceneManager.LoadScene("Stage1");
        ChangeSceneName("1. ��� ��� �����ϱ�");
        pip = 0;
        StartCoroutine(Paper(3));

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
