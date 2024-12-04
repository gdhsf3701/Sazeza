using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    }

    public void ChangeSceneName(string name)
    {
        ChangName.text = "당고 만들기 게임.exe : " + name;
    }

    public void SetScore()
    {
       scroe.text = "현재점수 : " + GameManager.Instance.Coin;
    }

    public void SetTooltip(string a , int p)
    {
        if(p == 1)
        {
            toolTip1.text = a;
            toolTip1P.text = a;
           
        }
        else if(p == 2)
        {
            toolTip2.text = a;
            toolTip2P.text = a;
        }
        else
        {
            toolTip3.text = a;


            toolTip3P.text = a;
        }
        
        
    }


}
