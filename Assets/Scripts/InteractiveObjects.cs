using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    [SerializeField] private Transform InteractorSource;
    [SerializeField] private float InteractRange;

    [SerializeField] LayerMask interactableLayer;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
               // Debug.Log(hitInfo.transform.gameObject.name, hitInfo.transform.gameObject);

                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    MonoBehaviour scriptComponent = interactObj as MonoBehaviour; //Falopa de chatgpt para chequear si el script esta prendido
                    if (scriptComponent != null && scriptComponent.enabled)
                    {
                        interactObj.Interact();
                    }
                }
            }
        }
    }
}
