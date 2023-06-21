using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySprites : MonoBehaviour
{
    public List<PickableItem> PickableItemsList;
    [SerializeField] GameObject SpritePrefab;
    List<GameObject> InventoryObjects;

    private void Start()
    {
        PickableItemsList = new List<PickableItem>();
        InventoryObjects = new List<GameObject>();
    }

    public void AddNewInventorySprites(PickableItem pickableItem)
    {
        SpritePrefab.GetComponent<Image>().sprite = pickableItem.GetIcon();
        GameObject inventorySprite = GameObject.Instantiate(SpritePrefab, transform);
        inventorySprite.name = pickableItem.GetName();

        InventoryObjects.Add(inventorySprite);
        PickableItemsList.Add(pickableItem);
    }

    public void RemoveInventoryObjectWithName(string objectName)
    {
        for (int i = 0; i < PickableItemsList.Count; i++)
        {
            if (PickableItemsList[i].GetName() == objectName)
            {
                PickableItemsList.RemoveAt(i);
                Destroy(InventoryObjects[i]);
                InventoryObjects.RemoveAt(i);
            }
        }
    }
}
