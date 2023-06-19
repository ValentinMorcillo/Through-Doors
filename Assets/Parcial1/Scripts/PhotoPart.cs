using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPart : MonoBehaviour
{
    [SerializeField] PickableItem pickableItemReference;

    public int IDPart;
    public bool IsVisualized;
   [HideInInspector] public string PhotoName;

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
}
