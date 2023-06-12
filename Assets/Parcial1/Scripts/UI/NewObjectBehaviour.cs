using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewObjectBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] InventorySprites inventorySprites;

    GameObject descriptionContainer;
    Queue<PickableItem> itemQueue = new Queue<PickableItem>();

    private bool isCoroutineRunning = false;

    private void Start()
    {
        descriptionContainer = description.transform.parent.parent.gameObject;
    }

    public void GotNewItem(PickableItem pickableItem)
    {

        itemQueue.Enqueue(pickableItem);
    }

    private IEnumerator WaitToShowInventory(PickableItem currentItem)
    {
        isCoroutineRunning = true;

        descriptionContainer.SetActive(true);
        description.text = currentItem.GetDescription();

        yield return new WaitForSeconds(3f);

        descriptionContainer.SetActive(false);
        inventorySprites.AddNewInventorySprites(currentItem.GetIcon(), currentItem.GetName());

        isCoroutineRunning = false;
    }

    private void Update()
    {
        if (!isCoroutineRunning)
        {
            if (itemQueue.Count > 0)
            {
                StartCoroutine(WaitToShowInventory(itemQueue.Dequeue()));
            }
        }

    }


}
