using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialToChildren : MonoBehaviour
{
    public Material targetMaterial;

    void Start()
    {
        SetMaterialRecursively(transform);
    }

    void SetMaterialRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Renderer renderer = child.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.material = targetMaterial;
            }

            // Llama a esta función recursivamente para los hijos del hijo actual.
            SetMaterialRecursively(child);
        }
    }
}
