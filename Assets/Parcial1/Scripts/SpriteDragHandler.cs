using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteDragHandler : MonoBehaviour
{
    [SerializeField] Camera secondCamera;
    public UnityEvent<string> SnappedPhoto;

    private Vector3 initialPosition;
    private Vector3 initialScreenPosition;

    PhotoPart photoPart;
    PartsContainerPhotos partsContainer;

    AudioSource audioSource;

    private void Awake()
    {
        partsContainer = transform.GetComponentInParent<PartsContainerPhotos>();
        photoPart = transform.GetComponent<PhotoPart>();
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnMouseDown()
    {
        // Obtener la posición inicial del objeto en viewport
        initialPosition = secondCamera.WorldToViewportPoint(transform.position);

        // Obtener la posición inicial del mouse en pantalla
        initialScreenPosition = Input.mousePosition;
        audioSource.Play();
    }

    private void OnMouseDrag()
    {
        Vector3 screenOffset = Input.mousePosition - initialScreenPosition;

        // Convertir la diferencia de pantalla a diferencia en viewport
        Vector3 viewportOffset = new Vector3(screenOffset.x / Screen.width, screenOffset.y / Screen.height, 0.0f);

        // Calcular la nueva posición en viewport sumando la diferencia de viewport a la posición inicial en viewport
        Vector3 newPosition = initialPosition + viewportOffset;

        // Limitar la posición en viewport dentro del rango de 0 a 1
        newPosition.x = Mathf.Clamp01(newPosition.x);
        newPosition.y = Mathf.Clamp01(newPosition.y);

        // Convertir la nueva posición en viewport a coordenadas del mundo
        Vector3 worldPosition = secondCamera.ViewportToWorldPoint(newPosition);

        // Actualizar la posición del objeto
        transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);
    }

    private void OnMouseUp()
    {
        audioSource.Play();

        if (partsContainer.CheckPhotoInCorrectPivot(photoPart))
        {
            SnappedPhoto.Invoke(photoPart.PhotoName);
            Destroy(this);
        }
        else
        {
            //Depende de lo que queramos lo podemos volver a poner en su posicion inicial
            transform.position = secondCamera.ViewportToWorldPoint(initialPosition);
        }
    }


}
