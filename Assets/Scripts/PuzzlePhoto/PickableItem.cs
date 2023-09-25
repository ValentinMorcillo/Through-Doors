using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PickeableItemType
{
    photo = 0, none
}

public class PickableItem : MonoBehaviour, IInteractable
{
    public UnityEvent<PickableItem> InteractPickableItem;

    [SerializeField] string itemName;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] PickeableItemType itemType;

    AudioManager am;
    
    private void Start()
    {
        am = AudioManager.Get();
    }

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

    public PickeableItemType GetItemType()
    {
        return itemType;
    }

    public void Interact()
    {
        InteractPickableItem.Invoke(this);
        am.PlayPickUpItemSound();
        Destroy(gameObject); 
    }
}
