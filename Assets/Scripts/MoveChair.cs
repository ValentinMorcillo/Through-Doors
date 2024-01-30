using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChair : MonoBehaviour, IInteractable
{
    [SerializeField] Transform playerTransform;
    Vector3 offSet;
    private bool isAttached = false;

    void Update()
    {
        if (isAttached)
        {
            // Mueve la silla junto al jugador.
            offSet = Camera.main.transform.forward;
            transform.position = playerTransform.position + offSet;
            transform.rotation = playerTransform.rotation;
        }
    }

    // Método para adjuntar la silla al jugador.
    public void AttachToPlayer(Transform player)
    {
        playerTransform = player;
        isAttached = true;
    }

    // Método para desvincular la silla del jugador.
    public void DetachFromPlayer()
    {
        playerTransform = null;
        isAttached = false;
    }

    public void Interact()
    {
        if (isAttached)
        {
            DetachFromPlayer();
        }
        else
        {
            AttachToPlayer(playerTransform);
        }
    }
}
