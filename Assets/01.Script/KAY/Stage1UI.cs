using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage1UI : MonoBehaviour
{
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        var chang = root.Q<VisualElement>("Chang");

      
        chang.pickingMode = PickingMode.Ignore;
    }
}
