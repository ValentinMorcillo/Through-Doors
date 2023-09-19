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

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.enabled)
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
        if (other.CompareTag("Player") && this.enabled)
        {
            outline.enabled = false;

            if (instructionPanel != null)
            {
                instructionPanel.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        outline.enabled = false;

        if (instructionPanel != null)
        {
            instructionPanel.gameObject.SetActive(false);
        }
    }
}
