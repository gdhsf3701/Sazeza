using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePos : MonoBehaviour
{
    Camera main;
    private void Awake()
    {
        main = Camera.main;
    }
    private void Update()
    {
        transform.position = main.WorldToScreenPoint(Input.mousePosition);
    }
}
