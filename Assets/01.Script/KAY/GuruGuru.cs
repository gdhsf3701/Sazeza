using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuruGuru : MonoBehaviour
{
    private bool isRotating = false;
    private float rotationSpeed;
    private int rotationDirection;

    void Start()
    {
        StartCoroutine(RandomGuru());
    }

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, rotationSpeed * rotationDirection * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartRotation();

        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            StopRotation();
        }
       
    }
    


    IEnumerator RandomGuru()
    {
        rotationSpeed = UnityEngine.Random.Range(300, 400);  
        rotationDirection = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1; 
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(RandomGuru());
    }

    
    public void StartRotation()
    {
        isRotating = true;
    }
    public void StopRotation()
    {
        isRotating = false;
    }


   
}
