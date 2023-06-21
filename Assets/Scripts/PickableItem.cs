using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PickeableItemType
{
    photo = 0
}

public class PickableItem : MonoBehaviour, IInteractable
{
    public UnityEvent<PickableItem> InteractPickableItem;

    [SerializeField] string itemName;
    [SerializeField] string description;
    [SerializeField] Sprite icon;
    [SerializeField] PickeableItemType itemType;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        transform.position = Vector3.down * 1000;
        Destroy(gameObject, 2.0f); //Se hace esta negrada para qe no se destruya el objeto qe hace el sonido
    }
}
