using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPart : MonoBehaviour
{
    [SerializeField] PickableItem pickableItemReference;

   [HideInInspector] public string PhotoName;
    
    public int IDPart;
    public bool IsVisualized;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        PhotoName = pickableItemReference.GetName();
    }

    private void Update()
    {
        if (IsVisualized)
        {
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

    public void SendImageToBackground(string NameToPhoto)
    {
        if (NameToPhoto == PhotoName)
        {
            spriteRenderer.sortingOrder = 0;
        }
    }
}
