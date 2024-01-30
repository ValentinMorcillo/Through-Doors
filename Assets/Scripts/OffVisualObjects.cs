using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffVisualObjects : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToOff;


    private void OnEnable()
    {
        foreach (GameObject objOff in objectsToOff)
        {
            objOff.SetActive(false);
        }
    }

    private void OnDisable()
    {
        foreach (GameObject objOff in objectsToOff)
        {
            objOff.SetActive(true);
        }
    }

}
