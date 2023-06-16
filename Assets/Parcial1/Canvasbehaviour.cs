using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvasbehaviour : MonoBehaviour
{
    Camera cam;
    void Awake()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        transform.rotation = cam.transform.rotation;
    }
}
