using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ToolkitManager : MonoBehaviour
{
   static public ToolkitManager Instance { get; private set; }
    private Label ChangName;
    private Label scroe;

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


    }

    public void ChangeSceneName(string name)
    {
        ChangName.text = "��� ����� ����.exe : " + name;
    }

    public void SetScore()
    {
       scroe.text = "�������� : " + GameManager.Instance.Coin;
    }


}
