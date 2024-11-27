using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShow : MonoBehaviour
{
    private Transform[] WaterPoses;
    private void Awake()
    {
        WaterPoses = transform.GetComponentsInChildren<Transform>();
    }
}
