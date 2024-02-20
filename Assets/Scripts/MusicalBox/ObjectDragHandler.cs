using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectDragHandler : MonoBehaviour
{
    [SerializeField] Camera secondCamera;
    [SerializeField] Transform PictureObject;

    public UnityEvent<string> SnappedMusicBoxPart;

    private Vector3 initialPosition;
    private Vector3 initialScreenPosition;

    MusicalBoxPart musicBoxPart;
    ContainerMusicBoxParts partsContainer;

    AudioSource audioSource;

    private void Awake()
    {
        partsContainer = transform.GetComponentInParent<ContainerMusicBoxParts>();
        musicBoxPart = transform.GetComponent<MusicalBoxPart>();
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

        if (partsContainer.CheckMusicPartInCorrectPivot(musicBoxPart))
        {
            SnappedMusicBoxPart.Invoke(musicBoxPart.muscialBoxPartName);
           // gameObject.transform.SetParent(PictureObject);
            Destroy(this);
        }
        else
        {
            //Depende de lo que queramos lo podemos volver a poner en su posicion inicial
            transform.position = secondCamera.ViewportToWorldPoint(initialPosition);
        }
    }


}
