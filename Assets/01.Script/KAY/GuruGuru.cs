using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuruGuru : MonoBehaviour
{
    private bool isRotating = false;
    private float rotationSpeed;
    private int rotationDirection;

    void Start()
    { 
        RandomGuru();
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
        if(Input.GetKeyDown (KeyCode.D))
        {
            DasiSet();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotationSpeed++;
        }
    }
    


    private void RandomGuru()
    {
        rotationSpeed = UnityEngine.Random.Range(150f, 400f);  
        rotationDirection = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1; 
    }

    
    public void StartRotation()
    {
        isRotating = true;
    }


    public void StopRotation()
    {
        isRotating = false;
    }

  
    public void DasiSet()
    {
        RandomGuru();
    }
}
