using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
  [SerializeField] float speedH;
  [SerializeField] float speedV;

    float moveH;
    float moveV;
    private void OnMouseDrag()
    {
        moveH -= speedH * Input.GetAxis("Mouse X");
        moveV += speedV * Input.GetAxis("Mouse Y");


        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles = new Vector3(moveV, moveH, 0.0f);
        }
    }

}



