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
        transform.position = (Vector2)main.ScreenToWorldPoint(Input.mousePosition);
    }
}
