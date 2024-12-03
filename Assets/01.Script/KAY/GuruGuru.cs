using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuruGuru : MonoBehaviour
{
    private float rotationSpeed;
    private int rotationDirection;

    void Start()
    {
        StartCoroutine(RandomGuru());
    }

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * rotationDirection * Time.deltaTime);
    }
    


    IEnumerator RandomGuru()
    {
        rotationSpeed = UnityEngine.Random.Range(300, 400);  
        rotationDirection = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1; 
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(RandomGuru());
    }
}
