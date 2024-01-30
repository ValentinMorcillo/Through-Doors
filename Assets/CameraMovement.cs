using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public Transform[] waypoints;  // Puntos de la ruta
    public float speed = 5f;       // Velocidad de movimiento

    private int currentWaypoint = 0;

    void Start()
    {
        // Llama a la función MoveToWaypoint() al inicio para iniciar el movimiento
        MoveToWaypoint();
    }

    void MoveToWaypoint()
    {
        // Verifica si hay puntos de la ruta disponibles
        if (currentWaypoint < waypoints.Length)
        {
            // Calcula la duración del tween basada en la velocidad y Time.deltaTime
            float duration = Vector3.Distance(transform.position, waypoints[currentWaypoint].position) / (speed * Time.deltaTime);

            // Utiliza Dotween para mover la cámara al siguiente punto de la ruta
            transform.DOMove(waypoints[currentWaypoint].position, duration)
                .OnComplete(MoveToNextWaypoint);

            // Utiliza LookAt para que la cámara mire hacia el próximo punto
            transform.DOLookAt(waypoints[currentWaypoint].position, 1.0f);
        }
    }

    void MoveToNextWaypoint()
    {
        // Cambia al siguiente punto de la ruta
        currentWaypoint++;

        // Llama a la función MoveToWaypoint() para continuar el movimiento
        MoveToWaypoint();
    }
}

