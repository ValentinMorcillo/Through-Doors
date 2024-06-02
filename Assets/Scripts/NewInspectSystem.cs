using EvolveGames;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Class made for the NewInspectSystem that allows any object with the Inspectable tag to be view.
/// Does not change the functionality of the other/older object already applied. Only for the new Ones.
/// </summary>
public class NewInspectSystem : MonoBehaviour
{
    [Header("=== New Inspect System ===========")]
    [Space(10)]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject descriptionItemPanel;
    [SerializeField] private TextMeshProUGUI txtdescriptionPanel;
    [SerializeField] private Transform inspectableObjectPosition;
    [SerializeField] private float raycastDistance;
    [SerializeField] private bool isViewing;

    [Header("=== Inspections Settings===========")]
    [Space(10)]
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField, Range(0.5f,1.0f)] private float minScale; //setear en realidad que el tamaño este basado por cada gameObject;
    [SerializeField, Range(0.8f, 2.0f)] private float maxScale; // setear como máximo 2 veces el tamaño real.
    [SerializeField, Range(0.5f, 1.0f)] private float initialShowScale; // la escala por defecto a mostrar al principio.

    [Header("=== Camera Settings ===========")]
    [Space(10)]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform currentObject;
    private Vector3 initialPosition;

    [Header("=== Object to View Elements ===========")]
    [Space(10)]
    private Vector3 objectInitialPosition;
    private Quaternion objectInitialRotation;
    [SerializeField] private Vector3 objectInitialScale;
    InspectObjectType type;

    void Start()
    {
        mainCamera = Camera.main;
        raycastDistance = 1.2f;
        initialPosition = mainCamera.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { InspectItem(); }
        if (isViewing) {RotateObject();ZoomObject();}
        if (Input.GetKeyDown(KeyCode.Q)) { ResetView(); }

    }

    /// <summary>
    /// Method in charge of activating the inspect mode when the player interacts with a inspectable item.
    /// </summary>
    private void InspectItem()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,raycastDistance))
        {
            if (hit.transform.CompareTag("Inspectable") && isViewing == false)
            {
                type = hit.transform.gameObject.GetComponent<InspectObjectType>();
                if (type.GetObjectType() == true) //significa que tiene texto.
                {
                    descriptionItemPanel.SetActive(true);
                    txtdescriptionPanel.text = string.Empty;
                    txtdescriptionPanel.text = type.itemDescriptionText;
                }
                //preguntar si el mismo tiene texto y en base a eso hacerlo aparecer o sino seguir con el resto del codigo.
                currentObject = hit.transform;
                objectInitialPosition = hit.transform.position;
                objectInitialRotation = hit.transform.rotation;
                objectInitialScale = currentObject.localScale;
                //tener en cuenta que la idea que todos los objetos partan de una escala de 1,1,1. Si no es así, meterlos dentro de un parent que si lo tenga.
                if (type.OverrideScale()==true)
                {
                    currentObject.localScale = new Vector3(type.initialScale, type.initialScale, type.initialScale);
                }
                else
                {
                    currentObject.localScale = new Vector3 (initialShowScale, initialShowScale,initialShowScale); 
                }

                Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, mainCamera.WorldToScreenPoint(inspectableObjectPosition.position).z);
                Vector3 worldCenter = mainCamera.ScreenToWorldPoint(screenCenter);
                //inspectableObjectPosition.position = worldCenter;
                currentObject.position = worldCenter;

                Collider collider = currentObject.GetComponent<Collider>();
                collider.enabled = false;
                playerController.canRotateCamera = false;
                playerController.enabled = false;
                mainCamera.transform.LookAt(currentObject);
                isViewing = true;
                //generar un collider especial que delimite la ubicacion del jugador.
            }
        }
    }

    /// <summary>
    /// Method in charge of rotating the object in view while the player isViewing.
    /// </summary>
    void RotateObject()
    {
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            currentObject.Rotate(Vector3.up, -rotationX, Space.World);
            currentObject.Rotate(Vector3.right, rotationY, Space.World);
        }
    }

    /// <summary>
    /// Method in charge of zoom between min and max scale sizes of the object.
    /// In order for this to work properly it will be necessary for the scale of either the object of the parent to be 1,1,1.
    /// </summary>
    void ZoomObject()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            Vector3 newScale = currentObject.localScale + Vector3.one * scroll * zoomSpeed;
            if (type.OverrideScale() == true)
            {
                newScale.x = Mathf.Clamp(newScale.x, type.minScale, type.maxScale);
                newScale.y = Mathf.Clamp(newScale.y, type.minScale, type.maxScale);
                newScale.z = Mathf.Clamp(newScale.z, type.minScale, type.maxScale);
            }
            else
            {
                newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
                newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
                newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);
            }
            currentObject.localScale = newScale;
        }
    }

    /// <summary>
    /// Method in charge of reseting the state of both the object and player after viewing the item itself.
    /// </summary>
    public void ResetView()
    {
        if (type.GetObjectType() == true) 
        {
            descriptionItemPanel.SetActive(false);
            txtdescriptionPanel.text = string.Empty;
        }
        currentObject.position = objectInitialPosition;
        currentObject.rotation = objectInitialRotation;
        currentObject.localScale = objectInitialScale;
        Collider collider = currentObject.GetComponent<Collider>();
        collider.enabled = true;
        currentObject = null;
        playerController.enabled = true;
        playerController.canRotateCamera = true;
        isViewing = false;

    }
}
