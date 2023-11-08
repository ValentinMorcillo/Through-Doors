using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalBoxPart : MonoBehaviour
{
    [SerializeField] PickableItem pickableItemReference;

    [HideInInspector] public string muscialBoxPartName;

    public int IDPart;
    public bool IsVisualized;
    MeshRenderer meshRenderer;

    void Awake()
    {
        meshRenderer = transform.GetComponentInChildren<MeshRenderer>();
        muscialBoxPartName = pickableItemReference.GetName();
    }

    private void Update()
    {
        if (IsVisualized)
        {
            meshRenderer.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }
}
