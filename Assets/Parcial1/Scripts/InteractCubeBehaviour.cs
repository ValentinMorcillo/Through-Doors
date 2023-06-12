using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCubeBehaviour : MonoBehaviour, IInteractable
{
    Outline outline;

    Vector3 originalPosition;
    Vector3 direction;
    bool movingForward = true;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void Start()
    {
        originalPosition = transform.position;
        direction = -transform.forward;
    }

    public void Interact()
    {
        float distance = Vector3.Distance(transform.position, originalPosition);

        if (distance >= 10)
        {
            movingForward = false;
        }
        else if (distance <= 0)
        {
            movingForward = true;
        }

        if (movingForward)
        {
            transform.position += direction;
        }
        else
        {
            transform.position -= direction;
        }


        //        Debug.Log(Random.Range(0, 100));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            outline.enabled = false;
        }
    }
}
