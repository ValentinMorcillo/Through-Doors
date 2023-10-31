using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDancer : MonoBehaviour
{
    public bool isActive = false;
     float rotationSpeed = 300.0f; // Velocidad de rotación en grados por segundo.

    private void Update()
    {
        if (isActive)
        {
            // Girar el objeto a una velocidad constante en Update.
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}
