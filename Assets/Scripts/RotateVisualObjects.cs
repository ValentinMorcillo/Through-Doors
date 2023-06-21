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
    private bool isDragging;

    void Start()
    {
        initialRotation = transform.rotation;
        isDragging = false;
    }

    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            moveH -= speedH * Input.GetAxis("Mouse X");
            moveV -= speedV * Input.GetAxis("Mouse Y");

            Quaternion newRotation = Quaternion.Euler(0.0f,moveH, moveV);
            transform.rotation = initialRotation * newRotation;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        moveH = 0;
        moveV = 0;
        transform.rotation = initialRotation;
    }
}
