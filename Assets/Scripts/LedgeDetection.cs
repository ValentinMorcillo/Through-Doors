using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] LayerMask climbableLayer;

    private PlayerMovement player;

    private bool canDetect;

    private void Awake()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        if (canDetect)
        {
            player.ledgeDetected = Physics.CheckSphere(transform.position, radius, climbableLayer);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canDetect = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            canDetect = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
