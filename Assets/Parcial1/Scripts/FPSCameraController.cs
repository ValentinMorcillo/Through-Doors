using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{

    Camera cam;
    float mouseHorizontal = 3.0f;
    float mouseVertical = 2.0f;
    float minRotation = -65.0f;
    float maxRotation = 60.0f;

    float h_mouse, v_mouse; 
    
    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        h_mouse += mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, h_mouse, 0);

    }
}
