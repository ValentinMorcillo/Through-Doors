using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Outline))]
public class OutlineObjects : MonoBehaviour
{
    Outline outline;
    [SerializeField] Canvas instructionPanel;

    void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = true;

            if (instructionPanel != null)
            {
                instructionPanel.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = false;
            if (instructionPanel != null)
            {
                instructionPanel.gameObject.SetActive(false);
            }
        }
    }
}
