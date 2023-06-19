using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateVisualObjects : MonoBehaviour
{
    [SerializeField] float speedH;
    [SerializeField] float speedV;

    private Quaternion initialRotation;


    float moveH;
    float moveV;

    void Start()
    {
        initialRotation = transform.rotation;
    }

    private void OnMouseDrag()
    {
        moveH -= speedH * Input.GetAxis("Mouse X");
        moveV += speedV * Input.GetAxis("Mouse Y");


        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(moveV, moveH, 0.0f);
        }
    }


    private void OnMouseUp()
    {
        //Depende de lo que queramos lo podemos volver a poner en su posicion inicial
        transform.rotation = initialRotation;
    }
}
