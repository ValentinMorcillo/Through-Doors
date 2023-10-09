using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorIsActive : MonoBehaviour
{
    MonoBehaviour[] components;

    private void Awake()
    {
        components = new MonoBehaviour[3];

        components[0] = GetComponentInChildren<Outline>();
        components[1] = GetComponentInChildren<OutlineObjects>();
        components[2] = GetComponentInChildren<InteractDoor>();
    }

    public void OnEnableDoor()
    {
        ToggleComponents(true);
    }

    public void OnDisableDoor()
    {
        ToggleComponents(false);
    }

    public void ToggleComponents(bool isActive)   //Usar para cuando la puerta esta abierta
    {
        foreach (MonoBehaviour component in components)
        {
            if (component != null) // Verifica si el componente existe antes de habilitarlo/deshabilitarlo
            {
                component.enabled = isActive;
            }
        }
    }
}
