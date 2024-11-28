using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public bool canWater = true;
    private void OnDisable()
    {
        canWater = true;
    }
}
