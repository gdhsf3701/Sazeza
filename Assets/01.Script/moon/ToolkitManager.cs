using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    private void Awake()
    {

        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ChangName = root.Q<Label>("ScenName");
        scroe = root.Q<Label>("Score");
        var chang = root.Q<VisualElement>("Chang");
        chang.pickingMode = PickingMode.Ignore;
        toolTip1 = root.Q<Label>("Tooltip1");
        toolTip2= root.Q<Label>("Tooltip2");
        toolTip3 = root.Q<Label>("Tooltip3");
        toolTip1P = root.Q<Label>("Tooltip1p");
        toolTip2P = root.Q<Label>("Tooltip2p");
        toolTip3P = root.Q<Label>("Tooltip3p");
        tooltipPaper = root.Q<VisualElement>("TooltipPaper");

        StartCoroutine(Paper());

    }

    IEnumerator Paper()
    {
        tooltipPaper.style.display = DisplayStyle.Flex;
        
        yield return new WaitForSeconds(3f);

        tooltipPaper.style.display = DisplayStyle.None;
        tooltipPaper.pickingMode = PickingMode.Ignore;

    }

    public void ChangeSceneName(string name)
    {
        ChangName.text = "당고 만들기 게임.exe : " + name;
    }

    public void SetScore()
    {
       scroe.text = "현재점수 : " + GameManager.Instance.Score;
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
