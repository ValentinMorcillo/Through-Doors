using UnityEngine;
using DG.Tweening;

public class CameraRotate : MonoBehaviour
{
    public float rotationSpeed = 30f; //    VIDEO 4 : rotationSpeed = 30f;

    void Start()
    {
        // Llama a la función para iniciar la rotación
        RotateCamera();
    }

    void RotateCamera()
    {
        // Obtiene la rotación actual de la cámara
        Vector3 currentRotation = transform.eulerAngles;

        // Calcula la rotación final sumándole 90 grados al eje Y
        Vector3 targetRotation = new Vector3(currentRotation.x, currentRotation.y + 90f, currentRotation.z);

        // Utiliza Dotween para animar la rotación hacia la rotación final
        transform.DORotate(targetRotation, 90f / rotationSpeed)
            .SetEase(Ease.Linear);  // Configura la curva de interpolación para una rotación lineal
    }
}
