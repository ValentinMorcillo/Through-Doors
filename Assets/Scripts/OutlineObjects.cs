using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class OutlineObjects : MonoBehaviour
{
    Outline[] outlines;
    [SerializeField] Canvas instructionPanel;

    void Awake()
    {
        outlines = GetComponentsInChildren<Outline>();
    }

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && this.enabled)
        {

            turnOnOutlines();

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
            turnOffOutlines();

            if (instructionPanel != null)
            {
                instructionPanel.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        turnOffOutlines();

        if (instructionPanel != null)
        {
            instructionPanel.gameObject.SetActive(false);
        }
    }

    void turnOffOutlines()
    {
        foreach (Outline o in outlines)
        {
            o.enabled = false;
        }
    }
    void turnOnOutlines()
    {
        foreach (Outline o in outlines)
        {
            o.enabled = true;
        }
    }

}
