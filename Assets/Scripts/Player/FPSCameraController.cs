using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    public float mouseSensitivity = 3.0f;
    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;

    private float h_mouse;
    private float v_mouse;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Obtén la entrada del ratón
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Aplica la sensibilidad del ratón
        h_mouse += mouseX * mouseSensitivity * Time.deltaTime;
        v_mouse -= mouseY * mouseSensitivity * Time.deltaTime; // El signo negativo invierte la dirección del movimiento vertical

        // Limita la rotación vertical dentro de los valores mínimos y máximos
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);

        // Aplica la rotación a la cámara (si está configurada en la cinemachine)
        transform.localRotation = Quaternion.Euler(v_mouse, h_mouse, 0f);
    }
}
