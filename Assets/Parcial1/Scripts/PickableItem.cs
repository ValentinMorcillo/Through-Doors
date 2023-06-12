using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickableItem : MonoBehaviour, IInteractable
{
    public UnityEvent<PickableItem> InteractPickableItem;
    [SerializeField] string itemName;
    [SerializeField] string description;
    [SerializeField] Sprite icon;

    public string GetName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return description;
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public void Interact()
    {
        InteractPickableItem.Invoke(this);
        Destroy(gameObject);
    }
}
