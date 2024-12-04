using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetSauce : MonoBehaviour
{
    private TextMeshProUGUI sauceScore;

    private int min = 8;
    private int max = 25;

    private void Awake()
    {
        sauceScore = GetComponent<TextMeshProUGUI>();
        Set();
    }

    private void Set()
    {
        sauceScore.text = Random.Range(min, max).ToString();
    }
}
